using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace TestCraft.AI.Generation
{
    public class CodeAnalyzer
    {
        public SyntaxTree Parse(string code)
        {
            return CSharpSyntaxTree.ParseText(code);
        }
    }
}
