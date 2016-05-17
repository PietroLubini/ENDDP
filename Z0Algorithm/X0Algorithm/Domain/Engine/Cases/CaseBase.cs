using X0Algorithm.Domain.Engine.Cases.Repeats;
using X0Algorithm.Domain.Extensibility.Engine.Cases;
using X0Algorithm.Domain.Extensibility.Engine.Cases.Repeats;

namespace X0Algorithm.Domain.Engine.Cases
{
    internal abstract class CaseBase : ICase
    {
        public virtual ICaseRepeat Repeat => CaseRepeats.Repeat10000;

        public abstract int TableDimension { get; }

        public abstract int PartTableDimension { get; }

        public override string ToString()
        {
            return $"{TableDimension} (Cycles = {Repeat.Count})";
        }
    }
}