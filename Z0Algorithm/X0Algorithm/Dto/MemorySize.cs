namespace X0Algorithm.Dto
{
    internal class MemorySize
    {
        public MemorySize(long bytes)
        {
            Bytes = bytes;
        }

        public long Bytes { get; private set; }

        public double KBytes => (double)Bytes / 1024;

        public double MBytes => KBytes / 1024;

        public void Merge(MemorySize memorySize)
        {
            Bytes += memorySize.Bytes;
        }

        public void CalculateAvarage(int n)
        {
            Bytes = Bytes / n;
        }
    }
}
