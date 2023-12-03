namespace Lexer;

public class LexicalToken
{
    public string OriginalToken { get; }

    public LexicalToken(string originalToken)
    {
        OriginalToken = originalToken;
    }
}
