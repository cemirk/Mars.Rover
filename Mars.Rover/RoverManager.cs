using System;
using System.Collections.Generic;
using System.Linq;
using Mars.Rover.Interfaces;
using Mars.Rover.Models;

namespace Mars.Rover
{
    public class RoverManager : IRoverManager
    {
        //In this class defined singleton but private constructor takes an argument in case of mocking queue mechanism
        private RoverManager(IQueueManager queueManager)
        {
            _rovers = new List<IRover>();
            _queueManager = queueManager;
        }

        private readonly IQueueManager _queueManager;

        public static Lazy<RoverManager> GetInstance(IQueueManager queueManager)
        {
            return new Lazy<RoverManager>(new RoverManager(queueManager));
        }

        private readonly List<IRover> _rovers;

        public void Connect(IRover rover)
        {
            if (!_rovers.Any(r => r.Name == rover.Name))
            {
                _rovers.Add(rover);
            }
        }

        public void ProcessCommand(string roverName, string commands)
        {
            _queueManager.Add(new QueueMessage {RoverName = roverName, Commands = commands});
        }

        public CommandResult Process()
        {
            if (_rovers.Any(x => x.State.Status == Status.Moving))
                return new CommandResult {ErrorMessage = "A rover is moving"};

            var queue = _queueManager.Dequeue();
            if (queue == null) return null;
            return !_rovers.Any(x => x.Name == queue.RoverName)
                ? new CommandResult {ErrorMessage = $"No rover connected called as {queue.RoverName}"}
                : _rovers.First(x => x.Name == queue.RoverName).ApplyCommands(queue.Commands);
        }
    }
}