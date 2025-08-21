namespace CleanArch.Domain.Entities.Validation;

public class DomainValidation(string message) : Exception(message)
{
    public static void When(bool hasError, string error)
    {
        if (hasError)
            throw new DomainValidation(error);
    }
}
