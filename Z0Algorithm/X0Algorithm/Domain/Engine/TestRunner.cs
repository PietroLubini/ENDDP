using System.Collections.Generic;
using System.Linq;
using X0Algorithm.Domain.Extensibility.Algorithms;
using X0Algorithm.Domain.Extensibility.Engine;
using X0Algorithm.Domain.Extensibility.Engine.TestCases;
using X0Algorithm.Dto;

namespace X0Algorithm.Domain.Engine
{
    internal class TestRunner : ITestRunner
    {
        private readonly IEnumerable<ITestCase> testCases;
        private readonly IEnumerable<IAlgorithm> algorithms;

        public TestRunner(IEnumerable<ITestCase> testCases, IEnumerable<IAlgorithm> algorithms)
        {
            this.testCases = testCases;
            this.algorithms = algorithms;
        }

        public IDictionary<IAlgorithm, TestReport> Run()
        {
            var result = new Dictionary<IAlgorithm, TestReport>();
            foreach (IAlgorithm algorithm in algorithms)
            {
                List<ITestCase> failedTestCases = testCases.Where(testCase => algorithm.IsSomebodyWon(testCase.Table).Result != testCase.Expected).ToList();
                result[algorithm] = new TestReport(algorithm, failedTestCases);
            }

            return result;
        }
    }
}