using System;
using System.Runtime.InteropServices;

namespace X0Algorithm.Domain.Imports
{
    internal static class DllImports
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        public static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);        
    }
}
