using CleanArch.Domain.Entities.Validation;
using System.Text.RegularExpressions;

namespace CleanArch.Domain.Helpers
{
    public static class EmailValidator
    {        
        private static readonly Regex EmailRegex = new Regex(
            @"^[A-Za-z0-9]+([._%+\-']?[A-Za-z0-9]+)*@[A-Za-z0-9\-]+(\.[A-Za-z0-9\-]+)*\.[A-Za-z]{2,}$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);        
        public static void Validate(string? email)
        {
            DomainValidation.When(string.IsNullOrEmpty(email), "Email is required.");

            DomainValidation.When(email!.Length > 254, "Email must be 254 characters or fewer.");

            DomainValidation.When(!EmailRegex.IsMatch(email), "Email format is invalid.");

            var atIndex = email.IndexOf('@');            
            DomainValidation.When(atIndex <= 0 || atIndex == email.Length - 1, "Email must contain a local part and a domain.");

            var local = email.Substring(0, atIndex);
            var domain = email.Substring(atIndex + 1);

            DomainValidation.When(local.Length > 64, "Local part must be 64 characters or fewer.");
            DomainValidation.When(domain.Length > 255, "Domain must be 255 characters or fewer.");

            DomainValidation.When(local.StartsWith(".") || local.EndsWith("."), "Local part cannot start or end with a dot.");
            DomainValidation.When(domain.StartsWith("-") || domain.EndsWith("-"), "Domain cannot start or end with a hyphen.");

            DomainValidation.When(local.Contains("..") || domain.Contains(".."), "Email cannot contain consecutive dots.");
            
            var lastDot = domain.LastIndexOf('.');
            DomainValidation.When(lastDot < 0, "Domain must contain a top-level domain (e.g. .com).");
            var tld = domain.Substring(lastDot + 1);
            DomainValidation.When(tld.Length < 2 || !Regex.IsMatch(tld, @"^[A-Za-z]+$"), "Top-level domain is invalid.");
        }        
        public static bool IsValid(string? email)
        {
            try
            {
                Validate(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
