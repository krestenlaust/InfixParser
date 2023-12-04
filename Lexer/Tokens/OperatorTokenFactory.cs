namespace Lexer.Tokens;

internal class OperatorTokenFactory : ILexicalTokenFactory<OperatorToken>
{
    public OperatorToken CreateLexicalizedToken(string token) => new OperatorToken(token);

    public bool IsTokenOfThisType(string token)
    {
        try
        {
            new OperatorToken(token);
        }
        catch (OperatorNotSupportedException)
        {
            return false;
        }

        return true;
    }
}
