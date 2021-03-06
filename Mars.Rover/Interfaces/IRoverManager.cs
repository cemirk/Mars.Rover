﻿using Mars.Rover.Models;

namespace Mars.Rover.Interfaces
{
    public interface IRoverManager
    {
        void Connect(IRover rover);
        void ProcessCommand(string roverName, string commands);
        CommandResult Process();
    }
}