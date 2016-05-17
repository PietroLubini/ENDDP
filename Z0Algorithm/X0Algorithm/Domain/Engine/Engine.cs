using System.Collections.Generic;
using System.Linq;
using System.Text;
using X0Algorithm.Domain.Extensibility.Algorithms;
using X0Algorithm.Domain.Extensibility.Engine;
using X0Algorithm.Dto;

namespace X0Algorithm.Domain.Engine
{
    internal class Engine : IEngine
    {
        private const int PlaceWidth = 5;
        private const int NameWidth = 15;
        private const int ValidWidth = 10;
        private const int SpentWidth = 12;
        private const int MemoryWidth = 12;
        private const int CycleCountWidth = 12;
        private const int TotalWidth = PlaceWidth + NameWidth + ValidWidth + SpentWidth + MemoryWidth + CycleCountWidth + 7;

        private readonly IPrinter printer;
        private readonly ITestRunner testRunner;
        private readonly IRunner runner;
        private readonly IReportProcessor reportProcessor;

        public Engine(
            IPrinter printer,
            ITestRunner testRunner,
            IRunner runner,
            IReportProcessor reportProcessor)
        {
            this.printer = printer;
            this.testRunner = testRunner;
            this.runner = runner;
            this.reportProcessor = reportProcessor;
        }

        public void Start()
        {
            RunTests();
            IEnumerable<CaseReport> reports = Run();
            ShowResults(reports);
        }        

        private void RunTests()
        {
            IDictionary<IAlgorithm, TestReport> testReports = testRunner.Run();
            PrintTestResults(testReports);
            PrintWaitToContinue();
            printer.Clear();
        }

        private IEnumerable<CaseReport> Run()
        {
            IEnumerable<CaseReport> reports = runner.Run();
            PrintWaitToContinue();
            printer.Clear();
            return reports;
        }

        private void ShowResults(IEnumerable<CaseReport> reports)
        {
            IEnumerable<ResultItem> resultTable = reportProcessor.GetWinners(reports);
            PrintResults(resultTable);
        }

        private void PrintTestResults(IDictionary<IAlgorithm, TestReport> testReports)
        {
            foreach (IAlgorithm algorithm in testReports.Keys)
            {
                printer.Debug(testReports[algorithm].ToString());
            }
        }

        private void PrintResults(IEnumerable<ResultItem> resultTable)
        {           
            List<ResultItem> results = resultTable.ToList();
            printer.Info("Total");
            PrintRow(TotalWidth);
            printer.Info($"|{"Place",PlaceWidth}|{"Author",NameWidth}|{"Valid",ValidWidth}|{"Avg.Spent,ms",SpentWidth}|{"Avg.Mem,Mb",MemoryWidth}|{"Avg.Cycles",CycleCountWidth}|");
            PrintRow(TotalWidth);
            for (var i = 0; i < results.Count; i++)
            {
                ResultItem resultItem = results[i];
                printer.Info($"|{i + 1,PlaceWidth}|{resultItem.Algorithm.Author,NameWidth}|{resultItem.IsTotalValid,ValidWidth}|{resultItem.TotalSpent,SpentWidth:F5}|{resultItem.TotalMemory,MemoryWidth:F5}|{resultItem.TotalCycleCount,CycleCountWidth:F0}|");
            }
            PrintRow(TotalWidth);
            printer.Info();

            PrintResultsPerCases(results);

            printer.GoToBegin();
        }

        private void PrintResultsPerCases(IEnumerable<ResultItem> resultTable)
        {
            IEnumerable<CaseReport> caseReports = reportProcessor.GetWinnersPerCases(resultTable);
            foreach (CaseReport caseReport in caseReports)
            {
                printer.Info($"Case {caseReport.Case}");
                PrintRow(TotalWidth);
                printer.Info($"|{"Place",PlaceWidth}|{"Author",NameWidth}|{"Valid",ValidWidth}|{"Spent, ms",SpentWidth}|{"Memory, Mb",MemoryWidth}|{"Cycles",CycleCountWidth}|");
                PrintRow(TotalWidth);
                for (var i = 0; i < caseReport.Reports.Count(); i++)
                {
                    Report report = caseReport.Reports.ElementAt(i);
                    printer.Info($"|{i + 1,PlaceWidth}|{report.Algorithm.Author,NameWidth}|{report.IsValid,ValidWidth}|{report.PerformanceMeasureData.Spent,SpentWidth:F5}|{report.PerformanceMeasureData.MemoryConsumption.MBytes,MemoryWidth:F5}|{report.PerformanceMeasureData.CycleCount,CycleCountWidth:F0}|");
                }
                PrintRow(TotalWidth);
                printer.Info();
            }
        }

        private void PrintRow(int width)
        {
            var line = new StringBuilder();
            for (var i = 0; i < width; i++)
            {
                line.Append("-");
            }
            printer.Info(line.ToString());
        }

        private void PrintWaitToContinue()
        {
            printer.DebugAndWait("Press Enter to continue...");
        }
    }
}