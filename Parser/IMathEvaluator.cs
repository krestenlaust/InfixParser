namespace Parser;

public interface IMathEvaluator<T>
{
    T Eval(string expression);
}
