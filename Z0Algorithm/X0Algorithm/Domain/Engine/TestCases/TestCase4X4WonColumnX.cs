using X0Algorithm.Domain.Extensibility.Engine.TestCases;

namespace X0Algorithm.Domain.Engine.TestCases
{
    internal class TestCase4X4WonColumnX : ITestCase
    {
        public string Name => "4x4. Won. Column. X";

        public int?[,] Table => new int?[,]
        {
            {0, 1, 1, 1},
            {1, 0, 1, 0},
            {0, 0, 1, 1},
            {1, 1, 1, 0}
        };

        public bool Expected => true;
    }
}