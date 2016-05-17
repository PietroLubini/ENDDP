using System;
using System.Collections.Generic;
using System.Linq;
using X0Algorithm.Domain.Extensibility.Algorithms;
using X0Algorithm.Domain.Extensibility.Engine;
using X0Algorithm.Domain.Extensibility.Engine.Cases;
using X0Algorithm.Dto;

namespace X0Algorithm.Domain.Engine
{
    internal class Runner : IRunner
    {
        private readonly Random random = new Random();

        private readonly IPrinter printer;
        private readonly IEnumerable<ICase> cases;
        private readonly ITableBuilder tableBuilder;
        private readonly IEnumerable<IAlgorithm> algorithms;
        private readonly IAlgorithmExecutor algorithmExecutor;
        private readonly IDefaultAlgorithm defaultAlgorithm;

        public Runner(
            IPrinter printer,
            ITableBuilder tableBuilder,
            IEnumerable<ICase> cases,
            IDefaultAlgorithm defaultAlgorithm,
            IAlgorithmExecutor algorithmExecutor,
            IEnumerable<IAlgorithm> algorithms)
        {
            this.printer = printer;
            this.tableBuilder = tableBuilder;
            this.cases = cases;
            this.defaultAlgorithm = defaultAlgorithm;
            this.algorithmExecutor = algorithmExecutor;
            this.algorithms = algorithms;
        }

        public IEnumerable<CaseReport> Run()
        {
            IEnumerable<IAlgorithm> participants = SnuffleParticipants().ToList();
            return cases.Select(@case => RunCase(@case, participants)).ToList();
        }

        private IEnumerable<IAlgorithm> SnuffleParticipants()
        {
            return algorithms.OrderBy(a => random.Next()).Select(a => a).ToList();
        }

        private CaseReport RunCase(ICase @case, IEnumerable<IAlgorithm> participants)
        {
            var casesResults = new List<IEnumerable<Report>>();
            List<IAlgorithm> participantsList = participants.ToList();
            printer.Debug($"Run case {@case}");
            for (var i = 0; i < @case.Repeat.Count; i++)
            {
                if ((i + 1) % @case.Repeat.PrintCount == 0)
                {
                    printer.Debug($"Cycle #{i + 1}");
                }
                int?[,] table = tableBuilder.Build(@case);
                AlgorithmResult expected = defaultAlgorithm.IsSomebodyWon(table);
                List<Report> reports = participantsList.Select(participant => algorithmExecutor.Run(table, expected.Result, participant)).ToList();
                casesResults.Add(reports);
            }
            printer.Debug();

            return GetResults(@case, casesResults);
        }

        private CaseReport GetResults(ICase @case, IEnumerable<IEnumerable<Report>> casesReports)
        {
            var result = new Dictionary<IAlgorithm, Report>();
            foreach (IEnumerable<Report> casesReport in casesReports)
            {
                foreach (Report report in casesReport)
                {
                    Report totalReport = result.ContainsKey(report.Algorithm)
                        ? result[report.Algorithm]
                        : new Report(true, new PerformanceMeasureData(0, new MemorySize(0)), report.Algorithm);
                    totalReport.Merge(report);
                    result[report.Algorithm] = totalReport;
                }
            }

            foreach (Report report in result.Values)
            {
                report.CalculateAvarage(@case.Repeat.Count);
            }

            return new CaseReport(@case, result.Values);
        }
    }
}