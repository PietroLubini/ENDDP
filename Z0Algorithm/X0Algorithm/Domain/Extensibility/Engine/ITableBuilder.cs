using X0Algorithm.Domain.Extensibility.Engine.Cases;

namespace X0Algorithm.Domain.Extensibility.Engine
{
    internal interface ITableBuilder
    {
        int?[,] Build(ICase @case);
    }
}
