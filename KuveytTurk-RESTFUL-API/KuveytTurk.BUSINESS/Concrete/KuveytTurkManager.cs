using System.Security.Cryptography;
using System.Text;
using KuveytTurk.BUSINESS.Abstract;
using KuveytTurk.CORE.Utilities.Results;
using KuveytTurk.ENTITIES.Dto;
using KuveytTurk.ENTITIES.Enum;
using KuveytTurk.ENTITIES.Helper;
using Newtonsoft.Json;
using Npgsql;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using RestSharp;

namespace KuveytTurk.BUSINESS.Concrete;

public class KuveytTurkManager : IKuveytTurkService
{
    public async Task<IDataResult<TokenDto>> GenerateAccessToken()
    {
        var client = new RestClient(EnvHelper.tokenUriProd);
        var request = new RestRequest();
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        request.AddParameter("grant_type", MethodsTypes.client_credentials);
        request.AddParameter("scope", EnvHelper.scopes);
        request.AddParameter("client_id", EnvHelper.clientIdProd);
        request.AddParameter("client_secret", EnvHelper.clientSecretProd);
        var response = await client.PostAsync(request);
        return new SuccessDataResult<TokenDto>(JsonConvert.DeserializeObject<TokenDto>(response.Content));
    }
    public string GetSignature(string? accessToken)
    {
        var privateKeyService = GetClientPrivateKeyFromRest(EnvHelper.privateKey);
        var key = privateKeyService.ExportParameters(true);
        string bodyData = string.Concat("",
            EnvHelper.identityUriProd.Split('?').Length <= 1 ? string.Empty : "?" + EnvHelper.identityUriProd.Split('?')[1]);
        var signedData = SignData(accessToken + bodyData, key);
        return signedData;
    }

    public string PostSignature(string accessToken, string data)
    {
        var privateKeyService = GetClientPrivateKeyFromRest(EnvHelper.privateKey);
        var key = privateKeyService.ExportParameters(true);
        string bodyData = data;
        var signedData = SignData(accessToken + bodyData, key);
        return signedData;
    }
    public async Task<IDataResult<AccountTransactionsDto.AccountTransactionsValue>> AccountTransactions(GetAccountTransactionsDto model)
    {
        if (string.IsNullOrEmpty(model.accessToken))
        {
            model.accessToken = (await GenerateAccessToken()).Data.access_token;
        }

        if (string.IsNullOrEmpty(model.signature))
        {
            model.signature = GetSignature(model.accessToken);
        }

        var client = new RestClient($"{EnvHelper.endpointUriProd}v3/accounts/1/transactions");
        var request = new RestRequest();
        request.AddHeader("Content-Type", "application/json");
        request.AddHeader("Authorization", $"Bearer {model.accessToken}");
        request.AddHeader("Signature", model.signature);
        var response = await client.GetAsync(request);
        return new SuccessDataResult<AccountTransactionsDto.AccountTransactionsValue>(
            JsonConvert.DeserializeObject<AccountTransactionsDto.AccountTransactionsValue>(response.Content));
    }
    public async Task<IDataResult<TransactionsListDto>> TransactionList(GetAccountTransactionsDto model)
    {
        if (string.IsNullOrEmpty(model.accessToken))
        {
            model.accessToken = (await GenerateAccessToken()).Data.access_token;
        }

        if (string.IsNullOrEmpty(model.signature))
        {
            model.signature = GetSignature(model.accessToken);
        } 
        var client = new RestClient($"{EnvHelper.endpointUriProd}v1/transactionvalidation/transactionlist");
        var request = new RestRequest();
        request.AddHeader("Content-Type", "application/json");
        request.AddHeader("Authorization", $"Bearer {model.accessToken}");
        request.AddHeader("Signature", model.signature);
        var response = await client.GetAsync(request);
        return new SuccessDataResult<TransactionsListDto>(JsonConvert.DeserializeObject<TransactionsListDto>(response.Content));
    }
    public async Task<IDataResult<CustomerIBANInfoDto>> CustomerIBANInfo(GetCustomerWithIBANDto model)
    {
        if (string.IsNullOrEmpty(model.accessToken))
        {
            model.accessToken = (await GenerateAccessToken()).Data.access_token;
        }

        if (string.IsNullOrEmpty(model.signature))
        {
            model.signature = GetSignature(model.accessToken);
        } 
        var client = new RestClient($"{EnvHelper.endpointUriProd}v1/moneytransfer/{model.iban}/customeribaninfo");
        var request = new RestRequest();
        request.AddHeader("Content-Type", "application/json");
        request.AddHeader("Authorization", $"Bearer {model.accessToken}");
        request.AddHeader("Signature", model.signature);
        var response = await client.GetAsync(request);
        return new SuccessDataResult<CustomerIBANInfoDto>(JsonConvert.DeserializeObject<CustomerIBANInfoDto>(response.Content));
    }
    string SignData(string data, RSAParameters key)
    {
        // Create a UnicodeEncoder to convert between byte array and string.
        var byteConverter = new ASCIIEncoding();
        var originalData = byteConverter.GetBytes(data);

        try
        {
            // Create a new instance of RSACryptoServiceProvider using the 
            // key from RSAParameters.  
            var rsaProvider = new RSACryptoServiceProvider();

            rsaProvider.ImportParameters(key);

            // Hash and sign the data. Pass a new instance of SHA1CryptoServiceProvider
            // to specify the use of SHA1 for hashing.
            var signedData = rsaProvider.SignData(originalData, "SHA256");
            return Convert.ToBase64String(signedData);
        }
        catch (CryptographicException e)
        {
            Console.WriteLine(e.Message);
        }

        return null;
    }
    RSACryptoServiceProvider GetClientPrivateKeyFromRest(string key)
    {
        using (TextReader privateKeyTextReader = new StringReader(key))
        {
            var readKeyPair = (AsymmetricCipherKeyPair)new PemReader(privateKeyTextReader).ReadObject();

            var privateKeyParams = ((RsaPrivateCrtKeyParameters)readKeyPair.Private);
            var cryptoServiceProvider = new RSACryptoServiceProvider();
            var parameters = new RSAParameters
            {
                Modulus = privateKeyParams.Modulus.ToByteArrayUnsigned(),
                P = privateKeyParams.P.ToByteArrayUnsigned(),
                Q = privateKeyParams.Q.ToByteArrayUnsigned(),
                DP = privateKeyParams.DP.ToByteArrayUnsigned(),
                DQ = privateKeyParams.DQ.ToByteArrayUnsigned(),
                InverseQ = privateKeyParams.QInv.ToByteArrayUnsigned(),
                D = privateKeyParams.Exponent.ToByteArrayUnsigned(),
                Exponent = privateKeyParams.PublicExponent.ToByteArrayUnsigned(),
            };

            cryptoServiceProvider.ImportParameters(parameters);
            return cryptoServiceProvider;
        }
    }
}