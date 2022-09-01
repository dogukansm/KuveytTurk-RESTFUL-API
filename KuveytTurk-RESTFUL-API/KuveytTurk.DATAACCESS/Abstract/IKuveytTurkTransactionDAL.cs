using KuveytTurk.CORE.DataAccess;
using KuveytTurk.ENTITIES.Concrete;

namespace KuveytTurk.DATAACCESS.Abstract;

public interface IKuveytTurkTransactionDAL : IEntityRepository<BankAccountTransactions>
{
    
}
