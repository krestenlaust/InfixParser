namespace Lexer;

public class LexicalToken(string originalToken)
{
    public string OriginalToken { get; } = originalToken;
}
