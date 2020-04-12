using Mars.Rover.Interfaces;

namespace Mars.Rover.Models
{
    public class CommandResult
    {
        public string RoverName { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public IRover Rover { get; set; }

        public override bool Equals(object? obj)
        {
            return this.Equals(obj as CommandResult);
        }
        private bool Equals(CommandResult obj)
        {
            return this.IsSuccess == obj.IsSuccess 
                   && this.RoverName == obj.RoverName 
                   && this.ErrorMessage==obj.ErrorMessage
                   && this.Rover.State.ToString() == obj.Rover.State.ToString();
        }
    }
}