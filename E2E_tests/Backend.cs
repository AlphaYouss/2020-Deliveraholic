using System.Diagnostics;

namespace E2E_tests
{
    public static class Backend
    {
        public static Process backend { get; set; }
        public static string fullPath { get; set; }
        public static string solutionPath { get; set; }


        public static void SetPaths(string fullPath, string solutionPath)
        {
            Backend.fullPath = fullPath;
            Backend.solutionPath = solutionPath;
        }


        public static void Run()
        {
            backend = Process.Start(fullPath);
        }


        public static void Stop()
        {
            backend.Kill();
            backend.WaitForExit();
            backend.Dispose();
        }
    }
}