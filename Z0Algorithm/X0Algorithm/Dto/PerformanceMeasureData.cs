namespace X0Algorithm.Dto
{
    internal class PerformanceMeasureData
    {
        public PerformanceMeasureData(double spent, MemorySize memoryConsumption)
        {
            Spent = spent;
            MemoryConsumption = memoryConsumption;
        }

        public double Spent { get; private set; }

        public MemorySize MemoryConsumption { get; }

        public double CycleCount { get; set; }

        public void Merge(PerformanceMeasureData performanceMeasureData)
        {
            Spent += performanceMeasureData.Spent;
            CycleCount += performanceMeasureData.CycleCount;
            MemoryConsumption.Merge(performanceMeasureData.MemoryConsumption);
        }

        public void CalculateAvarage(int n)
        {
            Spent = Spent / n;
            CycleCount = CycleCount / n;
            MemoryConsumption.CalculateAvarage(n);
        }
    }
}