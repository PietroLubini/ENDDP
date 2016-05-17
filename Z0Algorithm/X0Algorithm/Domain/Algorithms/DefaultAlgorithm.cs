using System;
using X0Algorithm.Domain.Extensibility.Algorithms;

namespace X0Algorithm.Domain.Algorithms
{
    internal class DefaultAlgorithm : AlgorithmBase, IDefaultAlgorithm
    {
        public override string Author => "Default";

        protected override bool GetResult(int?[,] table, int maxX, int maxY)
        {
            return GoDownAndRight(table, maxX) || GoDiagonal(table, maxX, false) || GoDiagonal(table, maxX, true);
        }

        private bool GoDownAndRight(int?[,] table, int length)
        {
            var step = 0;

            while (step < length)
            {
                AddCycle();

                if (Go(table, length, step, 0, true) || Go(table, length, 0, step, false))
                {
                    return true;
                }
                step++;
            }
            return false;
        }

        private bool Go(int?[,] table, int length, int currentX, int currentY, bool down)
        {
            int stepX = down ? 0 : 1;
            int stepY = down ? 1 : 0;
            return GoTo(table, length, currentX, currentY, x => x + stepX, y => y + stepY);
        }

        private bool GoDiagonal(int?[,] table, int length, bool right)
        {
            var stepX = 1;
            int stepY = right ? 1 : -1;
            return GoTo(table, length, 0, right ? 0 : length - 1, x => x + stepX, y => y + stepY);
        }

        private bool GoTo(int?[,] table, int length, int currentX, int currentY, Func<int, int> getNextX, Func<int, int> getNextY)
        {
            int nextX = getNextX(currentX);
            int nextY = getNextY(currentY);
            int? currentValue = table[currentX, currentY];
            while (nextX < length && nextY < length)
            {
                AddCycle();
                if (currentValue != table[nextX, nextY])
                {
                    return false;
                }
                nextX = getNextX(nextX);
                nextY = getNextY(nextY);
            }

            return true;
        }
    }
}
