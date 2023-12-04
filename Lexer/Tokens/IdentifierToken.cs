namespace Lexer.Tokens;

public class IdentifierToken(string originalToken, string identifier) : LexicalToken(originalToken)
{
    public string Identifier = identifier;
}
