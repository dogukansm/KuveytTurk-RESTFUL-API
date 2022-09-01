using KuveytTurk.CORE.Utilities.Results;
using KuveytTurk.ENTITIES.Dto;

namespace KuveytTurk.BUSINESS.Abstract;

public interface IKuveytTurkService
{
    Task<IDataResult<TokenDto>> GenerateAccessToken();
    string GetSignature(string accessToken);
    string PostSignature(string accessToken, string data);
    Task<IDataResult<AccountTransactionsDto.AccountTransactionsValue>> AccountTransactions(GetAccountTransactionsDto model);
    Task<IDataResult<TransactionsListDto>> TransactionList(GetAccountTransactionsDto model);
    Task<IDataResult<CustomerIBANInfoDto>> CustomerIBANInfo(GetCustomerWithIBANDto model);
}
