namespace X0Algorithm.Dto
{
    internal class CaseResult
    {
        public CaseResult(bool isValid, PerformanceMeasureData performanceMeasureData)
        {
            IsValid = isValid;
            PerformanceMeasureData = performanceMeasureData;
        }

        public PerformanceMeasureData PerformanceMeasureData { get; }

        public bool IsValid { get; }
    }
}