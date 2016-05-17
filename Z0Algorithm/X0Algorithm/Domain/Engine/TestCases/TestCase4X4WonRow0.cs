using X0Algorithm.Domain.Extensibility.Engine.TestCases;

namespace X0Algorithm.Domain.Engine.TestCases
{
    internal class TestCase4X4WonRow0 : ITestCase
    {
        public string Name => "4x4. Won. Row. 0";

        public int?[,] Table => new int?[,]
        {
            {0, 1, 0, 1},
            {1, 0, 1, 0},
            {0, 0, 0, 0},
            {1, 1, 0, 0}
        };

        public bool Expected => true;
    }
}