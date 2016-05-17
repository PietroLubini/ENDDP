using System;
using System.Diagnostics;
using X0Algorithm.Domain.Extensibility.Engine;
using X0Algorithm.Dto;

namespace X0Algorithm.Domain.Engine
{
    internal class PerformanceMeter : IPerformanceMeter
    {
        private Stopwatch timer;
        private long memoryBefore;

        public PerformanceMeasureData Measure(Action action)
        {
            ResetMemory();
            ResetTimer();

            action();

            return new PerformanceMeasureData(GetSpent(), new MemorySize(GetConsumedMemory()));
        }

        private void ResetTimer()
        {
            timer = new Stopwatch();
            timer.Start();
        }

        private double GetSpent()
        {
            timer.Stop();
            return timer.Elapsed.TotalMilliseconds;
        }

        private long GetConsumedMemory()
        {
            long memoryAfter = Process.GetCurrentProcess().WorkingSet64;
            return memoryAfter - memoryBefore;
        }

        private void ResetMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            memoryBefore = Process.GetCurrentProcess().WorkingSet64;
        }
    }
}