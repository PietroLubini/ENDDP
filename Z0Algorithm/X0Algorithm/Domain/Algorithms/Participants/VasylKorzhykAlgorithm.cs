using System.Linq;
using System.Threading.Tasks;

namespace X0Algorithm.Domain.Algorithms.Participants
{
    internal class VasylKorzhykAlgorithm : AlgorithmBase
    {
        public override string Author => "Vasyl Korzhyk";

        protected override bool GetResult(int?[,] table, int maxX, int maxY)
        {
            int n = maxX;

            if (n == 0)
            {
                return false;
            }

            var task1 = new Task<bool>(() => IsWin(table, n, 1));
            var task2 = new Task<bool>(() => IsWin(table, n, 0));

            task1.Start();
            task2.Start();

            return task1.Result || task2.Result;
        }

        private bool IsWin(int?[,] table, int size, int side)
        {
            var tempElements = new int?[size];

            if (IsWinLine(GetDiagonal(table, tempElements, true, size), side) || IsWinLine(GetDiagonal(table, tempElements, false, size), side))
            {
                return true;
            }

            int[] winColumns = GetWinColumns(table, size, side);

            if (winColumns == null)
            {
                return true;
            }

            for (var i = 0; i < size; i++)
            {
                AddCycle();
                if (winColumns[i] != -1)
                {
                    if (IsWinLine(GetColumn(table, tempElements, i, size), side))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private int[] GetWinColumns(int?[,] table, int size, int side)
        {
            var line = new int?[size];

            var winColumns = new int[size];

            for (var i = 0; i < size; i++)
            {
                AddCycle();
                if (table[i, 0] != side || table[i, size - 1] != side)
                {
                    if (table[i, 0] != side)
                    {
                        winColumns[0] = -1;
                    }

                    if (table[i, size - 1] != side)
                    {
                        winColumns[size - 1] = -1;
                    }

                    continue;
                }

                line = GetRow(table, line, i, size);

                if (IsWinLine(line, side))
                {
                    return null;
                }

                for (var k = 1; k < size - 1; k++)
                {
                    AddCycle();
                    if (winColumns[k] != -1 && line[k] != side)
                    {
                        winColumns[k] = -1;
                    }
                }
            }

            return winColumns;
        }

        private bool IsWinLine(int?[] line, int side)
        {
            return line.All(x => x == side);
        }

        private int?[] GetRow(int?[,] table, int?[] result, int rowIndex, int size)
        {
            for (var i = 0; i < size; i++)
            {
                AddCycle();
                result[i] = table[rowIndex, i];
            }

            return result;
        }

        private int?[] GetColumn(int?[,] table, int?[] result, int columnIndex, int size)
        {
            for (var i = 0; i < size; i++)
            {
                AddCycle();
                result[i] = table[i, columnIndex];
            }

            return result;
        }

        private int?[] GetDiagonal(int?[,] table, int?[] result, bool direct, int size)
        {
            if (direct)
            {
                for (var i = 0; i < size; i++)
                {
                    AddCycle();
                    result[i] = table[i, i];
                }
            }
            else
            {
                for (var i = 0; i < size; i++)
                {
                    AddCycle();
                    result[i] = table[i, size - i - 1];
                }
            }
            return result;
        }
    }
}
