namespace Parser.Lexer;

public class IdentifierToken : LexicalToken
{
    public string Identifier;

    public IdentifierToken(string originalToken, string identifier) : base(originalToken)
    {
    }
}
