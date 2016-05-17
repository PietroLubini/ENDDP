using System.Collections.Generic;
using System.Linq;
using System.Text;
using X0Algorithm.Domain.Extensibility.Algorithms;
using X0Algorithm.Domain.Extensibility.Engine.TestCases;

namespace X0Algorithm.Dto
{
    internal class TestReport
    {
        public TestReport(IAlgorithm algorithm, IEnumerable<ITestCase> failedTestCases)
        {
            FailedTestCases = failedTestCases;
            Algorithm = algorithm;
        }

        public IEnumerable<ITestCase> FailedTestCases { get; set; }

        public IAlgorithm Algorithm { get; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Author \"{Algorithm.Author}\"");
            builder.AppendLine($"Failed test cases: {FailedTestCases.Count()}");
            foreach (ITestCase testCase in FailedTestCases)
            {
                builder.AppendLine($"\t{testCase.Name}");
            }

            return builder.ToString();
        }
    }
}