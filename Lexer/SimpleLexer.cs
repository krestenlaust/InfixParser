using Lexer.Tokens;

namespace Lexer;

public class SimpleLexer : ILexer
{
    List<ILexicalTokenFactory<LexicalToken>> tokenFactories = new List<ILexicalTokenFactory<LexicalToken>>();

    public SimpleLexer()
    {
        tokenFactories.Add(new OperatorTokenFactory());
        tokenFactories.Add(new IntegralTokenFactory());
        tokenFactories.Add(new IdentifierTokenFactory());
    }

    public IEnumerable<LexicalToken> Lexer(IEnumerable<string> tokens)
    {
        foreach (var token in tokens)
        {
            var factory = tokenFactories.First(f => f.IsTokenOfThisType(token));
            yield return factory.CreateLexicalizedToken(token);
        }
    }
}
