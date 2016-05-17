using System.Collections.Generic;
using X0Algorithm.Dto;

namespace X0Algorithm.Domain.Extensibility.Engine
{
    internal interface IReportProcessor
    {
        IEnumerable<ResultItem> GetWinners(IEnumerable<CaseReport> casesReports);

        IEnumerable<CaseReport> GetWinnersPerCases(IEnumerable<ResultItem> resultItems);
    }
}