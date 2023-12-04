namespace Lexer;

public class SimpleLexer : ILexer
{
    ILexicalTokenFactory factory = new SimpleLexicalTokenFactory();

    public IEnumerable<LexicalToken> Lexer(IEnumerable<string> tokens)
    {
        foreach (var token in tokens)
        {
            yield return factory.CreateLexicalizedToken(token);
        }
    }
}
