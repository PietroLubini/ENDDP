using X0Algorithm.Domain.Extensibility.Engine.TestCases;

namespace X0Algorithm.Domain.Engine.TestCases
{
    internal class TestCase3X3WonFirstRow0 : ITestCase
    {
        public string Name => "3x3. Won. 1st row. 0";

        public int?[,] Table => new int?[,]
        {
            {0, 0, 0},
            {1, 1, 0},
            {1, 0, 1}
        };

        public bool Expected => true;
    }
}