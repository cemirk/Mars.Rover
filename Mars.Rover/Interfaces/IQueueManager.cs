using Mars.Rover.Models;

namespace Mars.Rover.Interfaces
{
    public interface IQueueManager
    {
        void Add(QueueMessage message);
        QueueMessage Dequeue();
    }
}