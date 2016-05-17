using X0Algorithm.Domain.Extensibility.Algorithms;

namespace X0Algorithm.Dto
{
    internal class Report
    {
        public Report(bool isValid, PerformanceMeasureData performanceMeasureData, IAlgorithm algorithm)
        {
            IsValid = isValid;
            PerformanceMeasureData = performanceMeasureData;
            Algorithm = algorithm;
        }

        public bool IsValid { get; private set; }

        public PerformanceMeasureData PerformanceMeasureData { get; }

        public IAlgorithm Algorithm { get; }

        public void Merge(Report report)
        {
            IsValid &= report.IsValid;
            PerformanceMeasureData.Merge(report.PerformanceMeasureData);
        }

        public void CalculateAvarage(int n)
        {
            PerformanceMeasureData.CalculateAvarage(n);
        }
    }
}