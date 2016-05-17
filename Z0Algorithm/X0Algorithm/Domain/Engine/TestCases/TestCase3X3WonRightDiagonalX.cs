using X0Algorithm.Domain.Extensibility.Engine.TestCases;

namespace X0Algorithm.Domain.Engine.TestCases
{
    internal class TestCase3X3WonRightDiagonalX : ITestCase
    {
        public string Name => "3x3. Won. Right Diagonal. X";

        public int?[,] Table => new int?[,]
        {
            {0, 1, 1},
            {0, 1, 1},
            {1, 0, 0}
        };

        public bool Expected => true;
    }
}