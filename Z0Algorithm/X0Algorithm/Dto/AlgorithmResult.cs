namespace X0Algorithm.Dto
{
    internal class AlgorithmResult
    {
        public AlgorithmResult(bool result, long cycleCount)
        {
            Result = result;
            CycleCount = cycleCount;
        }

        public bool Result { get; }

        public long CycleCount { get; }
    }
}