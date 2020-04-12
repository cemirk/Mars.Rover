using System;

namespace Mars.Rover
{
    public class QueueMessage
    {
        public Guid Id { get; }
        public string RoverName { get; set; }
        public string Commands { get; set; }

        public QueueMessage()
        {
            Id = Guid.NewGuid();
        }
    }
}