namespace Lexer.Tokens
{
    [Serializable]
    public class OperatorNotSupportedException : Exception
    {
        public OperatorNotSupportedException() { }
        public OperatorNotSupportedException(string message) : base(message) { }
        public OperatorNotSupportedException(string message, Exception inner) : base(message, inner) { }
        protected OperatorNotSupportedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
