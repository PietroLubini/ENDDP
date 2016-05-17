using System;
using System.Reflection;
using Ninject;
using X0Algorithm.Domain.Extensibility.Engine;
using X0Algorithm.Domain.Imports;

namespace X0Algorithm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            FullScreen();
            IEngine engine = GetRunner();

            engine.Start();
            Console.ReadLine();
        }

        private static void FullScreen()
        {
            DllImports.ShowWindow(DllImports.GetConsoleWindow(), 3);
        }

        private static IEngine GetRunner()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetCallingAssembly());
            return kernel.Get<IEngine>();
        }
    }
}