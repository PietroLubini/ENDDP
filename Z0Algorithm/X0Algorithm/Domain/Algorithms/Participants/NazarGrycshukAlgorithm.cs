using System;

namespace X0Algorithm.Domain.Algorithms.Participants
{
    internal class NazarGrycshukAlgorithm : AlgorithmBase
    {
        public override string Author => "Nazar Grycshuk";
        
        protected override bool GetResult(int?[,] mas, int maxX, int maxY)
        {
            int length = maxX;
            return CheckDiagonalLeftToRight(mas, length) || CheckDiagonalRightToLeft(mas, length);
        }

        public bool CheckHorizontal(int x, int?[,] mas, int length)
        {
            var y = 1;
            var prevY = 0;

            while (y < length && mas[prevY, x] == mas[y, x])
            {
                AddCycle();
                prevY = y;
                y++;
            }
            return y == length;
        }

        public bool CheckVertical(int y, int?[,] mas, int length)
        {
            var x = 1;
            var prevX = 0;
            while (x < length && mas[y, prevX] == mas[y, x])
            {
                AddCycle();
                prevX = x;
                x++;
            }
            return x == length;
        }

        private bool CheckDiagonalLeftToRight(int?[,] mas, int length)
        {
            int? sum = 0;
            for (var i = 0; i < length; i++)
            {
                AddCycle();
                sum += mas[i, i];
                if (CheckHorizontal(i, mas, length) || CheckVertical(i, mas, length))
                {
                    return true;
                }
            }
            return sum == 0 || sum == length;
        }

        public bool CheckDiagonalRightToLeft(int?[,] mas, int length)
        {
            int increasedLength = length - 1;
            var i = 1;
            var prevI = 0;
            while (i < length && mas[increasedLength - prevI, prevI] == mas[increasedLength - i, i])
            {
                AddCycle();
                prevI = i;
                i++;
            }
            return i == length;
        }
    }
}