namespace Lexer.Tokenizer;

public interface ITokenizer
{
    IEnumerable<string> Tokenize(string expression);
}
