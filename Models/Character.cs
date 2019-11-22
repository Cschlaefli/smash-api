using System.Collections.Generic;

namespace SmashApi.Models
{
    public class Character
    {
        public string Name {get; set;}
        public List<Move> Moves {get; set;}
        public int Id {get; set;}
        public int Jumps {get;set;}
        public bool Crawl {get; set;}
        public bool WallJump {get; set;}
        public bool WallCling {get; set;}
        public bool Zair {get; set;}
        public int SoftLanding {get; set;}
        public int HardLanding {get; set;}
        public int InitialDashFrames {get; set;}
        public int FullDashFrames {get;set;}
        public string ShortHop {get; set;}
        public string FullHop {get; set;}
        public string ShortHopFastFall {get; set;}
        public string FullHopFastFall {get; set;}
        public int Weight {get; set;}
        public float WalkSpeed {get;set;}
        public float Gravity {get; set;}
        public float RunSpeed {get; set;}
        public float InitialDash {get; set;}
        public float Acceleration {get; set;}
        public float Friction {get; set;}
        public float AirSpeed {get; set;}
        public float FastFallSpeed {get;set;}
        public float AirAcceleration {get; set;}
        public float AirFriction {get; set;}
        public float FallSpeed {get; set;}
        public float FastFall {get; set;}
        public float FullHopInitialSpeed {get;set;}
        public float FullHopHeight {get;set;}
        public float ShortHopHeight {get;set;}
        public float DoubleJumpHeight {get;set;}
        public int ShieldDrop {get; set;}
        public int ShieldGrab {get; set;}
        public int JumpSquat {get; set;}
    }
}