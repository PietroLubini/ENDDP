using System;
using log4net;
using X0Algorithm.Domain.Extensibility.Engine;

namespace X0Algorithm.Domain.Engine
{
    internal class Printer : IPrinter
    {
        private readonly ILog logger;

        public Printer()
        {
            logger = LogManager.GetLogger(typeof(Printer));
        }

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void GoToBegin()
        {
            Console.SetCursorPosition(0, 0);
        }

        public void DebugAndWait(string message)
        {
            Debug(message);
            Console.ReadLine();
        }
    }
}