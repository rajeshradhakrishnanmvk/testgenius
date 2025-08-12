using System;
using TestCraft.Core.Abstractions;

namespace TestCraft.Core.Frameworks
{
    public class MSTestFramework : ITestFramework
    {
        public string Name => "MSTest";

        public void RunTests()
        {
            // Implementation for running MSTest tests will go here
            Console.WriteLine("Running MSTest tests...");
        }
    }
}
