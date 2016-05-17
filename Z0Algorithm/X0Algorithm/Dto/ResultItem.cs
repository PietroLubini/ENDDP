using System.Collections.Generic;
using System.Linq;
using X0Algorithm.Domain.Extensibility.Algorithms;
using X0Algorithm.Domain.Extensibility.Engine.Cases;

namespace X0Algorithm.Dto
{
    internal class ResultItem
    {
        public ResultItem(IAlgorithm algorithm, IDictionary<ICase, CaseResult> casesResults)
        {
            Algorithm = algorithm;
            CasesResults = new Dictionary<ICase, CaseResult>(casesResults);
            IsTotalValid = CasesResults.Values.All(v => v.IsValid);
            TotalSpent = CasesResults.Values.Sum(v => v.PerformanceMeasureData.Spent) / CasesResults.Count;
            TotalMemory = CasesResults.Values.Sum(v => v.PerformanceMeasureData.MemoryConsumption.MBytes) / CasesResults.Count;
            TotalCycleCount = CasesResults.Values.Sum(v => v.PerformanceMeasureData.CycleCount) / CasesResults.Count;
        }

        public IAlgorithm Algorithm { get; set; }

        public IDictionary<ICase, CaseResult> CasesResults { get; }

        public bool IsTotalValid { get; }

        public double TotalSpent { get; }

        public double TotalMemory { get; }

        public double TotalCycleCount { get; }
    }
}