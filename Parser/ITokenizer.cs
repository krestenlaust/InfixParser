namespace Parser;

public interface ITokenizer
{
    IEnumerable<string> Tokenize(string expression);
}
