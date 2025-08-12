using TestCraft.Core.Abstractions;

namespace TestCraft.Execution.Runners
{
    public class TestRunner
    {
        private readonly ITestFramework _framework;

        public TestRunner(ITestFramework framework)
        {
            _framework = framework;
        }

        public void Run()
        {
            _framework.RunTests();
        }
    }
}
