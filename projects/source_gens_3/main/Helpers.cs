namespace System.Runtime.CompilerServices
{
#pragma warning disable CS9113 //  warning CS9113: Parameter '...' is unread.
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public sealed class InterceptsLocationAttribute(string filePath, int line, int character) : Attribute
    {
    }
#pragma warning restore CS9113 //  warning CS9113: Parameter '...' is unread.    
}