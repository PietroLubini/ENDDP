using System;
using X0Algorithm.Dto;

namespace X0Algorithm.Domain.Extensibility.Engine
{
    internal interface IPerformanceMeter
    {
        PerformanceMeasureData Measure(Action action);
    }
}