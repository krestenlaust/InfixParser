namespace Lexer.Tokens;

public class IntegralToken(string originalToken) : LexicalToken(originalToken)
{
    public Int64 IntegralValue { get; private set; } = Int64.Parse(originalToken);
}
