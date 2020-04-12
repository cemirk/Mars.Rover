using Mars.Rover.Models;

namespace Mars.Rover.Interfaces
{
    public interface IRover
    {
        string Name { get; set; }
        State State { get; set; }
        CommandResult ApplyCommands(string commands);
    }
}