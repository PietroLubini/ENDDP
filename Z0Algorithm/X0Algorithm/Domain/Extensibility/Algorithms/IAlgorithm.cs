using System;
using X0Algorithm.Dto;

namespace X0Algorithm.Domain.Extensibility.Algorithms
{
    internal interface IAlgorithm
    {
        string Author { get; }

        AlgorithmResult IsSomebodyWon(int?[,] table);
    }
}