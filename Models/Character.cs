using System.Collections.Generic;

namespace SmashApi.Models
{
    public class Character
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public List<Move> Moves {get; set;}
        public int Weight {get; set;}
        public float Gravity {get; set;}
        public float RunSpeed {get; set;}
        public float InitialDash {get; set;}
        public float AirSpeed {get; set;}
        public float TotalAirAcceleration {get; set;}
        public float FallSpeed {get; set;}
        public float FastFall {get; set;}
        public int ShieldGrab {get; set;}
        public int ShieldDrop {get; set;}
        public int JumpSquat {get; set;}
    
    }
}