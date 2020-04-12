using System;

namespace Mars.Rover
{
    public interface IRover
    {
        string Name { get; set; }
        State State { get; set; }
        string ApplyCommands(string commands);
    }
}