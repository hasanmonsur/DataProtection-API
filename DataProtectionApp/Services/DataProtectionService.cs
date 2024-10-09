using DataProtectionApp.Contacts;
using Microsoft.AspNetCore.DataProtection;
using System.Security.Cryptography;

namespace DataProtectionApp.Services
{
    public class DataProtectionService : IDataProtectionService
    {
        private readonly IDataProtector _protector;

        public DataProtectionService(IDataProtectionProvider provider)
        {
            // Create a protector with a purpose string
            _protector = provider.CreateProtector("MyApp.Purpose");
        }

        public string Protect(string input)
        {
            // Encrypt the input string
            string unprotectedData = "";
            try
            {
                unprotectedData = _protector.Protect(input);
            }
            catch (CryptographicException)
            {
                // Handle exception
            }
            return unprotectedData;
        }

        public string Unprotect(string input)
        {
            // Decrypt the input string
            string unprotectedData = "";
            try
            {
                unprotectedData = _protector.Unprotect(input);
            }
            catch (CryptographicException)
            {
                // Handle exception
            }
            return unprotectedData;
        }
    }
}
