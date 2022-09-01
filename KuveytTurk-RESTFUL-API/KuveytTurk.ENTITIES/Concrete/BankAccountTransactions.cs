using System.ComponentModel.DataAnnotations.Schema;
using KuveytTurk.CORE.Entities;

namespace KuveytTurk.ENTITIES.Concrete;

[Table("BankAccountTransactions")]
public class BankAccountTransactions : BaseEntity, IEntity
{ 
    [Column("suffix", Order = 1)]
    public int suffix { get; set; }
    [Column("date", Order = 2)]
    public DateTime date { get; set; }
    [Column("description", Order = 3)]
    public string description { get; set; }
    [Column("amount", Order = 4)]
    public decimal amount { get; set; }
    [Column("balance", Order = 5)]
    public decimal balance { get; set; }
    [Column("fxCode", Order = 6)]
    public string fxCode { get; set; }
    [Column("transactionReference", Order = 7)]
    public string transactionReference { get; set; }
    [Column("transactionCode", Order = 8)]
    public string transactionCode { get; set; }
    [Column("senderIdentityNumber", Order = 9)]
    public string senderIdentityNumber { get; set; }
}