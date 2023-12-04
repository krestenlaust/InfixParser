namespace Lexer;

public interface ILexicalTokenFactory<out T> where T : LexicalToken
{
    T CreateLexicalizedToken(string token);

    bool IsTokenOfThisType(string token);
}
