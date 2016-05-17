using X0Algorithm.Domain.Engine.Cases.Repeats;
using X0Algorithm.Domain.Extensibility.Engine.Cases.Repeats;

namespace X0Algorithm.Domain.Engine.Cases
{
    internal class Case10000 : CaseBase
    {
        public override ICaseRepeat Repeat => CaseRepeats.Repeat5;

        public override int TableDimension => 10000;

        public override int PartTableDimension => 10;
    }
}