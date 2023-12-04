namespace Lexer;

public interface ILexicalTokenFactory
{
    LexicalToken CreateLexicalizedToken(string token);
}
