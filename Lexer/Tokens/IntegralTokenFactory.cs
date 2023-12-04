namespace Lexer.Tokens;

public class IntegralTokenFactory : ILexicalTokenFactory<IntegralToken>
{
    public IntegralToken CreateLexicalizedToken(string token) => new IntegralToken(token);

    public bool IsTokenOfThisType(string token)
    {
        return Int64.TryParse(token, out _);
    }
}
