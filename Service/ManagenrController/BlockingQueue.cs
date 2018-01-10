using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManagenrController
{
    public class BlockingQueue<T>
    {
        private Semaphore s_busy;
        private ConcurrentQueue<T> concurrentQueue;
        public BlockingQueue():base()
        {
            s_busy = new Semaphore(0, int.MaxValue);
            concurrentQueue = new ConcurrentQueue<T>();
        }

        public void Enqueue(T item)
        {
            concurrentQueue.Enqueue(item);
            s_busy.Release();
        }

        public bool TryDequeue(out T result)
        {
            s_busy.WaitOne();
            return concurrentQueue.TryDequeue(out  result);
        }

        public int Count
        {
            get
            {
                return concurrentQueue.Count;
            }
        }
    }
}
