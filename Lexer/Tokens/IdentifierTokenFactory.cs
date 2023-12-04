namespace Lexer.Tokens;

public class IdentifierTokenFactory : ILexicalTokenFactory<IdentifierToken>
{
    public IdentifierToken CreateLexicalizedToken(string token) => new IdentifierToken(token);

    public bool IsTokenOfThisType(string token)
    {
        return true;
    }
}
