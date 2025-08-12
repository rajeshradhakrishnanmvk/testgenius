using System;
using TestCraft.Core.Abstractions;

namespace TestCraft.Core.Frameworks
{
    public class XUnitFramework : ITestFramework
    {
        public string Name => "xUnit";

        public void RunTests()
        {
            // Implementation for running xUnit tests will go here
            Console.WriteLine("Running xUnit tests...");
        }
    }
}
