using X0Algorithm.Domain.Extensibility.Algorithms;
using X0Algorithm.Dto;

namespace X0Algorithm.Domain.Extensibility.Engine
{
    internal interface IAlgorithmExecutor
    {
        Report Run(int?[,] table, bool expectedResult, IAlgorithm algorithm);
    }
}
