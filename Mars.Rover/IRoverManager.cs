using System.Collections;
using System.Collections.Generic;

namespace Mars.Rover
{
    public interface IRoverManager
    {
        void Connect(IRover rover);
        void ProcessCommand(string roverName, string commands);
        string Process();
    }
}