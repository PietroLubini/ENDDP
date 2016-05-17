using X0Algorithm.Domain.Extensibility.Engine.TestCases;

namespace X0Algorithm.Domain.Engine.TestCases
{
    internal class TestCase3X3WonFirstColumnX : ITestCase
    {
        public string Name => "3x3. Won. 1st column. X";

        public int?[,] Table => new int?[,]
        {
            {1, 0, 1},
            {1, 0, 0},
            {1, 1, 0}
        };

        public bool Expected => true;
    }
}