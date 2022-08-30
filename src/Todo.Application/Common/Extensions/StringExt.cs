namespace Todo.Application.Common.Extensions;

public static class StringExt
{
    public static bool IsEmpty(this string str) => string.IsNullOrWhiteSpace(str);

    public static bool IsNotEmpty(this string str) => !str.IsEmpty();
}
