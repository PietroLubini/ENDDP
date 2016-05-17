using X0Algorithm.Domain.Extensibility.Engine.Cases.Repeats;

namespace X0Algorithm.Domain.Engine.Cases.Repeats
{
    internal static class CaseRepeats
    {
        public static ICaseRepeat Repeat10000 => new CaseRepeat(10000, 1000);

        public static ICaseRepeat Repeat100 => new CaseRepeat(100, 10);

        public static ICaseRepeat Repeat5 => new CaseRepeat(5, 1);

        public static ICaseRepeat Repeat1 => new CaseRepeat(1, 1);

        public static ICaseRepeat Repeat0 => new CaseRepeat(0, 0);
    }
}