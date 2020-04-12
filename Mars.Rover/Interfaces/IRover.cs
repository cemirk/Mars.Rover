using Mars.Rover.Models;

namespace Mars.Rover.Interfaces
{
    public interface IRover
    {
        string Name { get; set; }
        State State { get; set; }
        string ApplyCommands(string commands);
    }
}