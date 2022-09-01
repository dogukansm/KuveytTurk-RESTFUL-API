namespace KuveytTurk.ENTITIES.Dto;

public class TransactionsListDto
{
    public TransactionContract transactionContract { get; set; }
    public bool success { get; set; }
    public List<object> results { get; set; }
    public string executionReferenceId { get; set; }
}

public class TransactionContract
{
    public double totalAmount { get; set; }
    public List<object> transactionList { get; set; }
}