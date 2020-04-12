namespace Mars.Rover
{
    public class State
    {
        public Status Status { get; set; }
        public Direction Direction { get; set; }
        // These items have been defined as virtual in case of using polar coordinate system (Liskov Substitution Principle)
        public virtual int X { get; set; }
        public virtual int Y { get; set; }
        public override string ToString()
        {
            return $"{X} {Y} {Direction}";
        }
    }
}