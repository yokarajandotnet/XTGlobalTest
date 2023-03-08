using Microsoft.AspNetCore.Authentication;

namespace DadJoke
{
    public class ApiKeyAuthenticationSchemeOptions: AuthenticationSchemeOptions
    {
        public string ApiKey { get; set; }
    }
}
