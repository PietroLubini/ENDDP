using X0Algorithm.Domain.Extensibility.Algorithms;
using X0Algorithm.Dto;

namespace X0Algorithm.Domain.Algorithms
{
    internal abstract class AlgorithmBase : IAlgorithm
    {
        private long cycleCount;

        public abstract string Author { get; }

        public AlgorithmResult IsSomebodyWon(int?[,] table)
        {
            cycleCount = 0;
            bool result = GetResult(table, table.GetLength(0), table.GetLength(1));

            return new AlgorithmResult(result, cycleCount);
        }

        protected abstract bool GetResult(int?[,] table, int maxX, int maxY);

        protected void AddCycle()
        {
            cycleCount++;
        }
    }
}