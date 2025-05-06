namespace FinApp.Application.Dtos
{
    public class OIDCSettingsDto
    {
        public string Authority { get; set; } = default!;
        public string ClientId { get; set; } = default!;
        public string ClientSecret { get; set; } = default!;
        public IList<string> Scopes { get; set; } = new List<string>();
    }
}
