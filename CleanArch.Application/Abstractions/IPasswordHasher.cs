namespace CleanArch.Application.Abstractions
{
    public interface IPasswordHasher
    {
        public string Hash(string password);
        bool Verify(string passwordRequest, string passwordHash);
    }
}
