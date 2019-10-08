using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using SmashApi.Models;
using Microsoft.AspNetCore.Cors;

namespace SmashApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly CharacterContext _context;
        public CharacterController(CharacterContext context){
            _context = context;
        }

        [HttpGet]
        [EnableCors("Permissive")]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            return await _context.Characters.ToListAsync();
        }
        [HttpGet("{id}")]
        [EnableCors("Permissive")]
        public async Task<ActionResult<Character>> GetCharacter(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if(character == null)
                return NotFound();
            await _context.Entry(character).Collection(c => c.Moves).LoadAsync();            
            return character;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [EnableCors("Enforcing")]
        public async Task<ActionResult<Character>> PostCharacter(Character character)
        {
            _context.Characters.Add(character);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCharacter), new {id = character.Id}, character);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [EnableCors("Enforcing")]
        public async Task<IActionResult> PutCharacter(int id, Character character)
        {
            if(id != character.Id)
                return BadRequest();
            
            _context.Entry(character).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [EnableCors("Enforcing")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {

            var character = await _context.Characters.FindAsync(id);
            if(character == null )
                return NotFound();
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
