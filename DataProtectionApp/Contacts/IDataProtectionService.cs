namespace DataProtectionApp.Contacts
{
    public interface IDataProtectionService
    {
        string Protect(string input);
        string Unprotect(string input);
    }
}