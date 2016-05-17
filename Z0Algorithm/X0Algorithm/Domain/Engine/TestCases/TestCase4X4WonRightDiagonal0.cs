using X0Algorithm.Domain.Extensibility.Engine.TestCases;

namespace X0Algorithm.Domain.Engine.TestCases
{
    internal class TestCase4X4WonRightDiagonal0 : ITestCase
    {
        public string Name => "4x4. Won. Right Diagonal. 0";

        public int?[,] Table => new int?[,]
        {
            {1, 0, 0, 0},
            {1, 0, 0, 1},
            {0, 0, 1, 0},
            {0, 1, 1, 0}
        };

        public bool Expected => true;
    }
}