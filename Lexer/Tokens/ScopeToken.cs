namespace Lexer.Tokens;

public enum Endness
{
    Start,
    End,
}

public class ScopeToken(string originalToken, Endness endness) : LexicalToken(originalToken)
{
    public Endness Endness = endness;
}
