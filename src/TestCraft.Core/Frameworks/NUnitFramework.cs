using System;
using TestCraft.Core.Abstractions;

namespace TestCraft.Core.Frameworks
{
    public class NUnitFramework : ITestFramework
    {
        public string Name => "NUnit";

        public void RunTests()
        {
            // Implementation for running NUnit tests will go here
            Console.WriteLine("Running NUnit tests...");
        }
    }
}
