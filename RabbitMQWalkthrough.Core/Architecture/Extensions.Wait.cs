using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQWalkthrough.Core.Architecture
{
    public static partial class Extensions
    {
        public static void Wait(this TimeSpan time)
        {
            //var are = new AutoResetEvent(false);
            //are.WaitOne(time);

            System.Threading.Thread.Sleep(time);
        }

        public static RateLimiter.TimeLimiter BuildRateLimiter(this int executionsPerSecond)
        {
            int seconds = 1;
            int executionsPerTime = executionsPerSecond;
            while (seconds < 5)
            {
                executionsPerTime += executionsPerSecond;
                seconds += 1;
            }

            var limiter = RateLimiter.TimeLimiter.GetFromMaxCountByInterval(executionsPerTime, TimeSpan.FromSeconds(seconds));
            return limiter;
        }


    }
}
