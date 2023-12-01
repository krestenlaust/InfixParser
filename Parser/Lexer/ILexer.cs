namespace Parser.Lexer;

public interface ILexer
{
    IEnumerable<LexicalToken> Lexer(IEnumerable<string> tokens);
}
