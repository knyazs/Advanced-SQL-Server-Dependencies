using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AdvancedSqlServerDependencies.Util
{
    public static class Parallel
    {
        public static void ForEach<T>(IEnumerable<T> enumerable, Action<T> action)
        {
            using (var cd = new Countdown(enumerable.Count()))
            {
                foreach (var current in enumerable)
                {
                    var captured = current;
                    ThreadPool.QueueUserWorkItem(x =>
                    {
                        action.Invoke(captured);
                        cd.Signal();
                    });
                }
                cd.Wait();
            }
        }
    }

    public class Countdown : IDisposable
    {
        private readonly ManualResetEvent _done;
        private volatile int _current;

        public Countdown(int total)
        {
            _current = total;
            _done = new ManualResetEvent(false);
        }

        public void Signal()
        {
            lock (_done)
            {
                if (_current > 0 && --_current == 0)
                    _done.Set();
            }
        }

        public void Wait()
        {
            _done.WaitOne();
        }

        public void Dispose()
        {
            _done.Dispose();
        }
    } 
}
