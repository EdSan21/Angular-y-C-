using FeriaUDEO2022API.ModelsApi;
namespace FeriaUDEO2022API.Repository
{
    public interface IEncryptRepository
    {
        string Encrypt2(string clearText);
        string Decrypt2(string cipherText);

        string Encrypt(string plainText);
        string Decrypt(string plaintext);
    }
}
