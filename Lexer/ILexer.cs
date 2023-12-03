namespace Lexer;

public interface ILexer
{
    IEnumerable<LexicalToken> Lexer(IEnumerable<string> tokens);
}
