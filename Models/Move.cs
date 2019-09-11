 namespace SmashApi.Models
{
    public class Move
    {                   
        public int Id {get; set;}
        public int CharacterId {get; set;}
        public string Name {get; set;}
        public string Advantage {get; set;}
        public string BaseDamage {get; set;}
        public string LandingLag {get; set;}
        public string Notes {get; set;}
        public string ShieldLag {get; set;}
        public string ShieldStun {get; set;}
        public string Startup {get; set;}
        public string TotalFrames {get; set;}
        public string Type {get; set;}
        public string WhichHitbox {get; set;}
    }
}