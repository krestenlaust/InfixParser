namespace Lexer.Tokens;

public enum MathOperator
{
    Add,
    Subtract,
    Multiply,
    Division,
    Equals,
}

public class OperatorToken(string originalToken) : LexicalToken(originalToken)
{
    public MathOperator OperatorType = originalToken switch
    {
        "+" => MathOperator.Add,
        "-" => MathOperator.Subtract,
        "*" => MathOperator.Multiply,
        "/" => MathOperator.Division,
        "=" => MathOperator.Equals,
        _ => throw new OperatorNotSupportedException($"{originalToken} is not recognized as an operator.")
    };

    public override bool IsTokenOfThisType(string token)
    {
        try
        {
            new OperatorToken(token);
        }
        catch (OperatorNotSupportedException)
        {
            return false;
        }

        return true;
    }
}
