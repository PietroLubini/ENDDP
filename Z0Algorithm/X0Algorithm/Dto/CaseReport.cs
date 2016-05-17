using System.Collections.Generic;
using X0Algorithm.Domain.Extensibility.Engine.Cases;

namespace X0Algorithm.Dto
{
    internal class CaseReport
    {
        public CaseReport(ICase @case, IEnumerable<Report> reports)
        {
            Case = @case;
            Reports = reports;
        }

        public ICase Case { get; set; }

        public IEnumerable<Report> Reports { get; set; }
    }
}