using X0Algorithm.Domain.Extensibility.Engine.Cases.Repeats;

namespace X0Algorithm.Domain.Extensibility.Engine.Cases
{
    internal interface ICase
    {
        ICaseRepeat Repeat { get; }

        int TableDimension { get; }

        int PartTableDimension { get; }
    }
}