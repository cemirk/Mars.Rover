namespace Mars.Rover
{
    public interface IQueueManager
    {
        void Add(QueueMessage message);
        QueueMessage Dequeue();
    }
}