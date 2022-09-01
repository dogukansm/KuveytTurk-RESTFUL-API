using KuveytTurk.CORE.DataAccess.EntityFramework;
using KuveytTurk.DATAACCESS.Abstract;
using KuveytTurk.DATAACCESS.Concrete.EntityFramework.Context;
using KuveytTurk.ENTITIES.Concrete;

namespace KuveytTurk.DATAACCESS.Concrete.EntityFramework;

public class EFKuveytTurkTransactionDAL : EfEntityRepositoryBase<BankAccountTransactions, BankContext>, IKuveytTurkTransactionDAL
{
    
}
