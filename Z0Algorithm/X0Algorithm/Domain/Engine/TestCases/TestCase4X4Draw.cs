using X0Algorithm.Domain.Extensibility.Engine.TestCases;

namespace X0Algorithm.Domain.Engine.TestCases
{
    internal class TestCase4X4Draw : ITestCase
    {
        public string Name => "4x4. Draw";

        public int?[,] Table => new int?[,]
        {
            {0, 1, 0, 1},
            {1, 0, 1, 0},
            {0, 0, 1, 1},
            {1, 1, 0, 0}
        };

        public bool Expected => false;
    }
}