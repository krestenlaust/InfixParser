﻿namespace Lexer;

public abstract class LexicalToken(string originalToken)
{
    public string OriginalToken { get; } = originalToken;
}
