using System.Collections.Generic;
using X0Algorithm.Domain.Extensibility.Algorithms;
using X0Algorithm.Dto;

namespace X0Algorithm.Domain.Extensibility.Engine
{
    internal interface ITestRunner
    {
        IDictionary<IAlgorithm, TestReport> Run();
    }
}