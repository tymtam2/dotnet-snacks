global using static System.Console;


using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Gens;


public class Helpers
{
    public static IEnumerable<Location> FindMethodInvocation(string methodName, string programText)
    {
        SyntaxTree tree = CSharpSyntaxTree.ParseText(programText);
        return FindMethodInvocation(methodName, tree);
    }

    public static IEnumerable<Location> FindMethodInvocation(string methodName, SyntaxTree tree)
    {
        CompilationUnitSyntax root = tree.GetCompilationUnitRoot();

        foreach (var m in root.Members)
        {
            if (m is GlobalStatementSyntax statement)
            {
                if (statement.Statement is ExpressionStatementSyntax gExpressionStatement)
                {
                    if (gExpressionStatement is ExpressionStatementSyntax expressionStatement)
                    {
                        if (expressionStatement.Expression is InvocationExpressionSyntax invocation)
                        {
                            if (invocation.Expression is MemberAccessExpressionSyntax memberInvocation)
                            {
                                if(memberInvocation.Name.ToString() == methodName)
                                {
                                    
                                    yield return memberInvocation.Name.GetLocation();
                                }
                            }
                        }
                    }
                }
            }
        }
    }



    string GetInterceptorFilePath(SyntaxTree tree, Compilation compilation)
    {
        // From https://github.com/dotnet/roslyn/blob/main/docs/features/interceptors.md
        return compilation.Options.SourceReferenceResolver?.NormalizePath(tree.FilePath, baseFilePath: null) ?? tree.FilePath;
    }

}
