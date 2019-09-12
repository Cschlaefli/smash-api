using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace SmashApi.Areas.Identity.Pages.Account.Manage
{
    public class ChangeRoleModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<ChangeRoleModel> _logger;
        private readonly IConfiguration _configuration;

        public ChangeRoleModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<ChangeRoleModel> logger,
            IConfiguration configuration)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Code")]
            public string Code { get; set; }
       }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            string role = _configuration.GetSection("RoleCodes").GetValue<String>(Input.Code.ToLower(), "");

            if(String.IsNullOrEmpty(role))
            {
                    _logger.LogInformation("User entered and invalid code");
                    ModelState.AddModelError(string.Empty, "Invalid Code");
                return Page();
            }else
            {
                var changeRoleResult = await _userManager.AddToRoleAsync(user, role);
                if (!changeRoleResult.Succeeded)
                {
                    foreach (var error in changeRoleResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return Page();
                }
            }
            await _signInManager.RefreshSignInAsync(user);
            _logger.LogInformation("User changed their role successfully.");
            StatusMessage = $"You have been added to the {role} group.";

            return RedirectToPage();
        }
    }
}
