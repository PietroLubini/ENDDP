using X0Algorithm.Domain.Extensibility.Engine.TestCases;

namespace X0Algorithm.Domain.Engine.TestCases
{
    internal class TestCase3X3Draw : ITestCase
    {
        public string Name => "3x3. Draw";

        public int?[,] Table => new int?[,]
        {
            {0, 1, 0},
            {1, 0, 1},
            {1, 0, 1}
        };

        public bool Expected => false;
    }
}