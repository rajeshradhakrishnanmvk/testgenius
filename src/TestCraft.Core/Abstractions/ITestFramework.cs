namespace TestCraft.Core.Abstractions
{
    public interface ITestFramework
    {
        string Name { get; }
        void RunTests();
    }
}
