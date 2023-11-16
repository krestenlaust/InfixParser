namespace Parser;

/// <summary>
/// Only supports operators denoted using a single character.
/// </summary>
public class SimpleTokenizer : ITokenizer
{
    readonly HashSet<char> delimiters = new HashSet<char>();

    public SimpleTokenizer()
    {
        delimiters.Add('+');
        delimiters.Add('-');
        delimiters.Add('*');
        delimiters.Add('/');
        delimiters.Add('(');
        delimiters.Add(')');
    }

    public string[] Tokenize(string expression)
    {
        List<string> tokens = new List<string>();

        int lastIndex = 0;
        for (int i = 0; i < expression.Length; i++)
        {
            if (!delimiters.Contains(expression[i]))
            {
                continue;
            }

            // Whatever was between this operator and the last one
            if (i - lastIndex > 0)
            {
                tokens.Add(expression[lastIndex..i].Trim());
            }

            // The operator itself
            tokens.Add(expression[i].ToString());
            lastIndex = i + 1;
        }

        if (lastIndex < expression.Length)
        {
            tokens.Add(expression[lastIndex..].Trim());
        }

        return tokens.ToArray();
    }
}