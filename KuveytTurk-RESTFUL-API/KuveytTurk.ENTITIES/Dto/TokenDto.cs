namespace KuveytTurk.ENTITIES.Dto;

public class TokenDto
{
    public string access_token { get; set; }
    public string token_type { get; set; }
    public string expires_in { get; set; }
    public string scope { get; set; }
}
