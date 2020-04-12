﻿using System;

namespace Mars.Rover
{
    class Program
    {
        static void Main(string[] args)
        {
            var rover1 = new Rover {Name = "Curiosity"};
            var rover2 = new Rover {Name = "InSight"};
            var rover3 = new Rover {Name = "Spirit"};
            var rover4 = new Rover {Name = "Perseverance"};

            var roverManager = RoverManager.GetInstance(QueueManager.Instance.Value).Value;
            roverManager.Connect(rover1);
            roverManager.Connect(rover4);
            roverManager.ProcessCommand("Curiosity", "5 5 1 2 N LMLMLMLMM");
            roverManager.ProcessCommand("Perseverance", "5 5 3 3 E MMRMMRMRRM");
            roverManager.ProcessCommand("Spirit", "5 5 3 3 E MMRMMRMRRM");
            var msg = "Started";
            while (msg != "")
            {
                msg = roverManager.Process();
                Console.WriteLine(msg);
            }
        }
    }
}