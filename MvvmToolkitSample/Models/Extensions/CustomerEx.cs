namespace MvvmToolkitSample.Models.Extensions;

public static class CustomerEx
{
    public static bool IsValid(this Customer? self)
    {
        return !string.IsNullOrEmpty(self?.FirstName) && !string.IsNullOrEmpty(self?.LastName);
    }

    public static bool IsNullOrNew(this Customer? self)
    {
        return self?.Id == 0;
    }
}
