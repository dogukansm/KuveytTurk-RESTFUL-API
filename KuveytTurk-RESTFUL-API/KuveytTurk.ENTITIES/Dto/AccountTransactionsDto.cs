namespace KuveytTurk.ENTITIES.Dto;

public class AccountTransactionsDto
{
    public class AccountTransactionsValue
    {
        public AccountTransactionsActivities value { get; set; }
    }

    public class AccountTransactionsActivities
    {
        public AccountTransactionsData[] accountActivities { get; set; }
    }

    public class AccountTransactionsData
    {
        public int suffix { get; set; }
        public DateTime date { get; set; }
        public string description { get; set; }
        public decimal amount { get; set; }
        public decimal balance { get; set; }
        public string fxCode { get; set; }
        public string transactionReference { get; set; }
        public string transactionCode { get; set; }
        public string senderIdentityNumber { get; set; }
    }
}
