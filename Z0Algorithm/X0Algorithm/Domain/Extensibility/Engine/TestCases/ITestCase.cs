namespace X0Algorithm.Domain.Extensibility.Engine.TestCases
{
    internal interface ITestCase
    {
        string Name { get; }

        int?[,] Table { get; }

        bool Expected { get; }
    }
}
