namespace Lexer.Tokens;

public class IdentifierToken(string originalToken) : LexicalToken(originalToken)
{
    public string Identifier = originalToken;
}
