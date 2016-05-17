using System.Collections.Generic;
using X0Algorithm.Dto;

namespace X0Algorithm.Domain.Extensibility.Engine
{
    internal interface IRunner
    {
        IEnumerable<CaseReport> Run();
    }
}