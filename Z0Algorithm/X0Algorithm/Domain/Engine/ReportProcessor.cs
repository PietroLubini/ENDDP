using System.Collections.Generic;
using System.Linq;
using X0Algorithm.Domain.Extensibility.Algorithms;
using X0Algorithm.Domain.Extensibility.Engine;
using X0Algorithm.Domain.Extensibility.Engine.Cases;
using X0Algorithm.Dto;

namespace X0Algorithm.Domain.Engine
{
    internal class ReportProcessor : IReportProcessor
    {
        public IEnumerable<ResultItem> GetWinners(IEnumerable<CaseReport> casesReports)
        {
            List<CaseReport> casesReportsList = casesReports.ToList();
            var participantResults = new Dictionary<IAlgorithm, IDictionary<ICase, CaseResult>>();
            foreach (CaseReport caseReport in casesReportsList)
            {
                foreach (Report report in caseReport.Reports)
                {
                    IDictionary<ICase, CaseResult> casesResults = participantResults.ContainsKey(report.Algorithm) ?
                        participantResults[report.Algorithm] : new Dictionary<ICase, CaseResult>();

                    casesResults[caseReport.Case] = new CaseResult(report.IsValid, report.PerformanceMeasureData);

                    participantResults[report.Algorithm] = casesResults;
                }
            }

            return participantResults.Select(r => new ResultItem(r.Key, r.Value)).OrderByDescending(p => p.IsTotalValid).ThenBy(p => p.TotalSpent);
        }

        public IEnumerable<CaseReport> GetWinnersPerCases(IEnumerable<ResultItem> resultItems)
        {
            var result = new Dictionary<ICase, List<Report>>();
            foreach (ResultItem resultItem in resultItems)
            {
                foreach (ICase @case in resultItem.CasesResults.Keys)
                {
                    List<Report> reports = result.ContainsKey(@case) ? result[@case] : new List<Report>();
                    reports.Add(new Report(resultItem.CasesResults[@case].IsValid, resultItem.CasesResults[@case].PerformanceMeasureData, resultItem.Algorithm));

                    result[@case] = reports;
                }
            }

            result.Keys.ToList().ForEach(c => result[c] = result[c]
                .OrderByDescending(r => r.IsValid)
                .ThenBy(r => r.PerformanceMeasureData.Spent)
                .ThenBy(r => r.PerformanceMeasureData.MemoryConsumption.Bytes)
                .ThenBy(r => r.PerformanceMeasureData.CycleCount)
                .ToList());

            return result.Select(r => new CaseReport(r.Key, r.Value)).ToList();
        }
    }
}