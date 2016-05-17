using System;
using System.Collections.Generic;
using System.Linq;

namespace X0Algorithm.Domain.Algorithms.Participants
{
    internal class AlexStrebkoAlgorithm : AlgorithmBase
    {
        private const int MinLineWeight = 0;

        public override string Author => "Alex Strebko";

        protected override bool GetResult(int?[,] table, int maxX, int maxY)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table));
            }

            int maxLineWeight = maxX;
            if (maxLineWeight == MinLineWeight)
            {
                throw new Exception("Input array is empty.");
            }

            return IsSomebodyWonByDiagonals(table, maxLineWeight)
                || IsSomebodyWonByRows(table, maxLineWeight)
                || IsSomebodyWonByColumns(table, maxLineWeight);
        }

        private bool IsSomebodyWonByDiagonals(int?[,] table, int maxLineWeight)
        {
            var diagonals = new List<int?[]>
            {
                GetDiagonal(table, maxLineWeight, x => 0 + x,  x => 0 + x)
            };
            int diagonalRightTopIndex = maxLineWeight - 1;
            diagonals.Add(GetDiagonal(table, maxLineWeight, x => 0 + x, x => diagonalRightTopIndex - x));

            return diagonals.Any(diagonal => IsSomebodyWonByVector(diagonal, maxLineWeight));
        }

        private bool IsSomebodyWonByColumns(int?[,] table, int maxLineWeight)
        {
            return IsSomebodyWonByVectors(table, maxLineWeight, GetColumn);
        }

        private bool IsSomebodyWonByRows(int?[,] table, int maxLineWeight)
        {
            return IsSomebodyWonByVectors(table, maxLineWeight, GetRow);
        }

        private bool IsSomebodyWonByVectors(int?[,] table, int maxLineWeight, Func<int?[,], int, int, int?[]> getTableItem)
        {
            for (var i = 0; i < maxLineWeight; i++)
            {
                AddCycle();
                int?[] currentVector = getTableItem(table, i, maxLineWeight);
                if (IsSomebodyWonByVector(currentVector, maxLineWeight))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsSomebodyWonByVector(int?[] vector, int maxLineWeight)
        {
            if (vector.All(x => x.HasValue))
            {
                int? currentItemWeight = vector.Sum();
                if (currentItemWeight == maxLineWeight || currentItemWeight == MinLineWeight)
                {
                    return true;
                }
            }

            return false;
        }

        private int?[] GetDiagonal(int?[,] table, int maxLineWeight, Func<int, int> getXCoordinate, Func<int, int> getYCoordinate)
        {
            var result = new int?[maxLineWeight];

            for (var i = 0; i < maxLineWeight; i++)
            {
                AddCycle();
                int xCoordinate = getXCoordinate(i);
                int yCoordinate = getYCoordinate(i);
                result[i] = table[xCoordinate, yCoordinate];
            }

            return result;
        }

        private int?[] GetVector(int maxLineWeight, Func<int, int?> getMatrixItem)
        {
            var result = new int?[maxLineWeight];

            for (var i = 0; i < maxLineWeight; i++)
            {
                AddCycle();
                result[i] = getMatrixItem(i);
            }

            return result;
        }

        private int?[] GetRow(int?[,] table, int row, int maxLineWeight)
        {
            return GetVector(maxLineWeight, x => table[row, x]);
        }

        private int?[] GetColumn(int?[,] table, int column, int maxLineWeight)
        {
            return GetVector(maxLineWeight, x => table[x, column]);
        }
    }
}