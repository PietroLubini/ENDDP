namespace X0Algorithm.Domain.Extensibility.Engine
{
    internal interface IPrinter
    {
        void Debug(string message = "");

        void Info(string message = "");

        void Clear();

        void GoToBegin();

        void DebugAndWait(string message);
    }
}