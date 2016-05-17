using X0Algorithm.Domain.Extensibility.Algorithms;
using X0Algorithm.Domain.Extensibility.Engine;
using X0Algorithm.Dto;

namespace X0Algorithm.Domain.Engine
{
    internal class AlgorithmExecutor : IAlgorithmExecutor
    {
        private readonly IPerformanceMeter performanceMeter;

        public AlgorithmExecutor(IPerformanceMeter performanceMeter)
        {
            this.performanceMeter = performanceMeter;
        }

        public Report Run(int?[,] table, bool expectedResult, IAlgorithm algorithm)
        {
            AlgorithmResult actual = null;
            PerformanceMeasureData performanceMeasureData = performanceMeter.Measure(() =>
             {
                 actual = algorithm.IsSomebodyWon(table);
             });
            performanceMeasureData.CycleCount = actual.CycleCount;

            return new Report(expectedResult == actual.Result, performanceMeasureData, algorithm);
        }
    }
}