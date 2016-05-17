using Ninject.Modules;
using X0Algorithm.Domain.Algorithms;
using X0Algorithm.Domain.Algorithms.Participants;
using X0Algorithm.Domain.Engine;
using X0Algorithm.Domain.Engine.Cases;
using X0Algorithm.Domain.Engine.TestCases;
using X0Algorithm.Domain.Extensibility.Algorithms;
using X0Algorithm.Domain.Extensibility.Engine;
using X0Algorithm.Domain.Extensibility.Engine.Cases;
using X0Algorithm.Domain.Extensibility.Engine.TestCases;

namespace X0Algorithm
{
    public class X0AlgorithmNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IPrinter>().To<Printer>();
            Bind<ITableBuilder>().To<TableBuilder>();
            Bind<IAlgorithmExecutor>().To<AlgorithmExecutor>();
            Bind<IDefaultAlgorithm>().To<DefaultAlgorithm>();
            Bind<IReportProcessor>().To<ReportProcessor>();
            Bind<ITestRunner>().To<TestRunner>();
            Bind<IRunner>().To<Runner>();
            Bind<IEngine>().To<Engine>();
            Bind<IPerformanceMeter>().To<PerformanceMeter>();

            BindTestCases();
            BindCases();
            BindParticipants();
        }

        private void BindTestCases()
        {
            Bind<ITestCase>().To<TestCase3X3Draw>();
            Bind<ITestCase>().To<TestCase3X3WonFirstColumn0>();
            Bind<ITestCase>().To<TestCase3X3WonFirstColumnX>();
            Bind<ITestCase>().To<TestCase3X3WonFirstRow0>();
            Bind<ITestCase>().To<TestCase3X3WonFirstRowX>();
            Bind<ITestCase>().To<TestCase3X3WonLastColumn0>();
            Bind<ITestCase>().To<TestCase3X3WonLastColumnX>();
            Bind<ITestCase>().To<TestCase3X3WonLastRow0>();
            Bind<ITestCase>().To<TestCase3X3WonLastRowX>();
            Bind<ITestCase>().To<TestCase3X3WonLeftDiagonal0>();
            Bind<ITestCase>().To<TestCase3X3WonLeftDiagonalX>();
            Bind<ITestCase>().To<TestCase3X3WonRightDiagonal0>();
            Bind<ITestCase>().To<TestCase3X3WonRightDiagonalX>();
            Bind<ITestCase>().To<TestCase4X4Draw>();
            Bind<ITestCase>().To<TestCase4X4WonColumn0>();
            Bind<ITestCase>().To<TestCase4X4WonColumnX>();
            Bind<ITestCase>().To<TestCase4X4WonRow0>();
            Bind<ITestCase>().To<TestCase4X4WonRowX>();
            Bind<ITestCase>().To<TestCase4X4WonLeftDiagonal0>();
            Bind<ITestCase>().To<TestCase4X4WonLeftDiagonalX>();
            Bind<ITestCase>().To<TestCase4X4WonRightDiagonal0>();
            Bind<ITestCase>().To<TestCase4X4WonRightDiagonalX>();
        }

        private void BindCases()
        {
            Bind<ICase>().To<Case3>();
            Bind<ICase>().To<Case4>();
            Bind<ICase>().To<Case10>();
            Bind<ICase>().To<Case100>();
            Bind<ICase>().To<Case1000>();
            Bind<ICase>().To<Case10000>();
        }

        private void BindParticipants()
        {
            Bind<IAlgorithm>().To<ArtemVelmakinAlgorithm>();
            Bind<IAlgorithm>().To<NazarGrycshukAlgorithm>();
            Bind<IAlgorithm>().To<VasylKorzhykAlgorithm>();
            Bind<IAlgorithm>().To<AlexStrebkoAlgorithm>();
        }
    }
}