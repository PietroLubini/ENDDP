using System;

namespace X0Algorithm.Domain.Algorithms.Participants
{
    internal class ArtemVelmakinAlgorithm : AlgorithmBase
    {
        public override string Author => "Artem Velmakin";

        protected override bool GetResult(int?[,] table, int maxX, int maxY)
        {
            int sideSize = maxX;

            //vertical
            int? result = CheckStraightLines(table, true, sideSize) ??
            //horisontal
            CheckStraightLines(table, false, sideSize) ??
            // \
            CheckDiagonal(table, false, sideSize) ??
            // /
            CheckDiagonal(table, true, sideSize);

            return result.HasValue;
        }

        private int? CheckStraightLines(int?[,] table, bool isVertical, int sideSize)
        {
            int lineValue;

            for (var x = 0; x < sideSize; x++)
            {
                AddCycle();
                lineValue = 0;

                for (var y = 0; y < sideSize; y++)
                {
                    AddCycle();
                    lineValue += isVertical ? table[x, y].Value : table[y, x].Value;

                    if (lineValue != 0 && lineValue != (y + 1))
                    {
                        break;
                    }

                    if (y + 1 == sideSize)
                    {
                        return lineValue == 0 ? 0 : 1;
                    }
                }
            }

            return null;
        }

        private int? CheckDiagonal(int?[,] table, bool inverse, int sideSize)
        {
            var diagonalValue = 0;

            for (var x = 0; x < sideSize; x++)
            {
                AddCycle();
                diagonalValue += inverse ? table[sideSize - 1 - x, x].Value : table[x, x].Value;

                if (diagonalValue != 0 && diagonalValue != (x + 1))
                {
                    break;
                }

                if (x + 1 == sideSize)
                {
                    return diagonalValue == 0 ? 0 : 1;
                }
            }

            return null;
        }
    }
}
