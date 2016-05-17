using X0Algorithm.Domain.Extensibility.Engine.TestCases;

namespace X0Algorithm.Domain.Engine.TestCases
{
    internal class TestCase3X3WonLeftDiagonalX : ITestCase
    {
        public string Name => "3x3. Won. Left Diagonal. X";

        public int?[,] Table => new int?[,]
        {
            {1, 0, 0},
            {1, 1, 0},
            {0, 0, 1}
        };

        public bool Expected => true;
    }
}