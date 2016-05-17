using System;
using X0Algorithm.Domain.Extensibility.Engine;
using X0Algorithm.Domain.Extensibility.Engine.Cases;
using X0Algorithm.Dto;

namespace X0Algorithm.Domain.Engine
{
    internal class TableBuilder : ITableBuilder
    {
        private readonly Random random = new Random((int)DateTime.Now.Ticks);

        public int?[,] Build(ICase @case)
        {
            if (@case.TableDimension % @case.PartTableDimension != 0)
            {
                throw new NotSupportedException($"Dimension should be divisible to {@case.PartTableDimension}");
            }
            var table = new int?[@case.TableDimension, @case.TableDimension];
            bool cellValue = Convert.ToBoolean(random.Next(1));
            for (var i = 0; i < @case.TableDimension / @case.PartTableDimension; i++)
            {
                for (var j = 0; j < @case.TableDimension / @case.PartTableDimension; j++)
                {
                    var partTable = new int?[@case.PartTableDimension, @case.PartTableDimension];

                    cellValue = BuildAndGetLastValue(partTable, cellValue);

                    for (var k = 0; k < @case.PartTableDimension; k++)
                    {
                        for (var l = 0; l < @case.PartTableDimension; l++)
                        {
                            table[i * @case.PartTableDimension + k, j * @case.PartTableDimension + l] = partTable[k, l];
                        }
                    }
                }
            }

            return table;
        }

        private bool BuildAndGetLastValue(int?[,] table, bool cellValue)
        {
            for (var i = 0; i < table.GetLength(0) * table.GetLength(1); i++)
            {
                Point point = GeneratePosition(table);
                table[point.X, point.Y] = Convert.ToInt32(cellValue);
                cellValue = !cellValue;
            }

            return cellValue;
        }

        private Point GeneratePosition(int?[,] table)
        {
            int x, y;
            int maxX = table.GetLength(0);
            int maxY = table.GetLength(1);
            do
            {
                x = random.Next(maxX);
                y = random.Next(maxY);
            }
            while (table[x, y] != null);

            return new Point(x, y);
        }
    }
}