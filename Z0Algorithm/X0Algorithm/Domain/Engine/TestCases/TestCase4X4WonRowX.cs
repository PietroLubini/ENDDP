using X0Algorithm.Domain.Extensibility.Engine.TestCases;

namespace X0Algorithm.Domain.Engine.TestCases
{
    internal class TestCase4X4WonRowX : ITestCase
    {
        public string Name => "4x4. Won. Row. X";

        public int?[,] Table => new int?[,]
        {
            {1, 0, 1, 0},
            {0, 1, 0, 1},
            {1, 1, 1, 1},
            {0, 0, 1, 1}
        };

        public bool Expected => true;
    }
}