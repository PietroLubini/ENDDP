using X0Algorithm.Domain.Engine.Cases.Repeats;
using X0Algorithm.Domain.Extensibility.Engine.Cases.Repeats;

namespace X0Algorithm.Domain.Engine.Cases
{
    internal class Case1000 : CaseBase
    {
        public override ICaseRepeat Repeat => CaseRepeats.Repeat100;

        public override int TableDimension => 1000;

        public override int PartTableDimension => 10;
    }
}