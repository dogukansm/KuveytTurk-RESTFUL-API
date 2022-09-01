namespace KuveytTurk.ENTITIES.Dto;

public class CustomerIBANInfoDto
{
    public Value value { get; set; }
    public bool success { get; set; }
    public List<object> results { get; set; }
    public string executionReferenceId { get; set; }
}

public class Value
{
    public string customerName { get; set; }
    public string bankName { get; set; }
    public int bankId { get; set; }
}