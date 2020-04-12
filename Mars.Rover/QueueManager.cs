using System;
using System.Collections.Generic;
using Mars.Rover.Interfaces;
using Mars.Rover.Models;

namespace Mars.Rover
{
    public class QueueManager : IQueueManager
    {
        private readonly Queue<QueueMessage> _queue;
        public static Lazy<IQueueManager> Instance => new Lazy<IQueueManager>(new QueueManager());
        private QueueManager()
        {
            _queue = new Queue<QueueMessage>();
        }
        
        public void Add(QueueMessage message)
        {
            _queue.Enqueue(message);
        }

        public QueueMessage Dequeue()
        {
            if (_queue.Count == 0) return null;
            return _queue.Dequeue();
        }
    }
}