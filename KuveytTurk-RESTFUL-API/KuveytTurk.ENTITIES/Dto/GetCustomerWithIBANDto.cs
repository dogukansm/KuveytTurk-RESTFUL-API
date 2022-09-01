namespace KuveytTurk.ENTITIES.Dto;

public class GetCustomerWithIBANDto
{
    public string? accessToken { get; set; }
    public string? signature { get; set; }
    public string? iban { get; set; }
}
