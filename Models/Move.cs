using System.Collections.Generic;

namespace SmashApi.Models
{
    public class Move
    {                   
        public int Id {get; set;}
        public int CharacterId {get; set;}
        public string Name {get; set;}
        public string NameJp {get;set;}
        public string SpecialName {get; set;}
        public List<Version> Versions {get;set;}
    }

    public class Version {
        public int Id {get;set;}
        public int MoveId {get; set;}
        public string Name {get; set;}
        public string Active {get;set;}
        public string Duration {get; set;}
        public float BaseDamage {get; set;}
        public string ShieldStun {get; set;}
        public string LandingLag {get; set;}
        public string LandingLagFrames {get; set;}
        public string Comment {get;set;}        
    }
}