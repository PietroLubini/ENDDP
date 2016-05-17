using X0Algorithm.Domain.Extensibility.Engine.Cases.Repeats;

namespace X0Algorithm.Domain.Engine.Cases.Repeats
{
    internal class CaseRepeat : ICaseRepeat
    {
        public CaseRepeat(int count, int printCount)
        {
            Count = count;
            PrintCount = printCount;
        }

        public int Count { get; }

        public int PrintCount { get; }
    }
}
