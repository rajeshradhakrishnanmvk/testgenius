using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using TestCraft.AI.Generation;
using TestCraft.Core.Abstractions;
using TestCraft.Core.Frameworks;
using TestCraft.Execution.Runners;

namespace TestCraft.CLI
{
    class Program
    {
        static int Main(string[] args)
        {
            var runCommand = new Command("run", "Run tests for a project")
            {
                new Option<string>(
                    "--framework",
                    getDefaultValue: () => "nunit",
                    description: "The test framework to use (nunit, xunit, mstest)")
            };

            runCommand.Handler = CommandHandler.Create<string>((framework) =>
            {
                ITestFramework testFramework;
                switch (framework?.ToLower())
                {
                    case "nunit":
                        testFramework = new NUnitFramework();
                        break;
                    case "xunit":
                        testFramework = new XUnitFramework();
                        break;
                    case "mstest":
                        testFramework = new MSTestFramework();
                        break;
                    default:
                        testFramework = new NUnitFramework();
                        break;
                }

                var runner = new TestRunner(testFramework);
                runner.Run();
            });

            var generateCommand = new Command("generate", "Generate tests for a C# file")
            {
                new Argument<string>("file", "The path to the C# file to generate tests for")
            };

            generateCommand.Handler = CommandHandler.Create<string>((file) =>
            {
                if (!File.Exists(file))
                {
                    Console.WriteLine($"Error: File not found at '{file}'");
                    return;
                }

                var sourceCode = File.ReadAllText(file);
                var generator = new TestGenerator();
                var generatedTest = generator.GenerateTest(sourceCode);

                Console.WriteLine("// Generated Test Code:");
                Console.WriteLine(generatedTest);
            });

            var rootCommand = new RootCommand
            {
                runCommand,
                generateCommand
            };
            
            rootCommand.Description = "TestCraft.NET - Intelligent Testing Platform";

            return rootCommand.InvokeAsync(args).Result;
        }
    }
}
