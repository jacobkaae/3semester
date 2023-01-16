using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

public class DummyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private string salt;

    public DummyAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock
        ) : base(options, logger, encoder, clock)
    {
        // Lav et 128-bit salt, som skal med i hash-funktionen når password hashes
        byte[] saltBytes = new byte[128 / 8];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetNonZeroBytes(saltBytes);
        }

        // Her er den nye salt:
        salt = Convert.ToBase64String(saltBytes);
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        // Vi undersøge lige om anonym adgang er tilladt
        var endpoint = Context.GetEndpoint();
        if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
        {
            // Hvis anonym adgang er tilladt, skal vi ikke lave authentication
            return Task.FromResult(AuthenticateResult.NoResult());
        }

        // Brugeroplysninger
        string passwordAdmin = "password123";
        string passwordCake = "cake123";

        

        // Lav en 256-bit hash af "password + salt" - og gør det 100.000 gange!
        // HMACSHA256 er navnet på hash-funktionen der anvendes herunder
        string hashedAdmin = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: passwordAdmin,
            salt: Convert.FromBase64String(salt),
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

        string hashedCake = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: passwordCake,
            salt: Convert.FromBase64String(salt),
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

        // Vi fisker en header ud hvor key er "Authorization"
        var authHeader = Request.Headers["Authorization"].ToString();

        // Vi tjekker efterfølgende på om "Authorization" findes, og på om dens value starte med "Password".
        if (authHeader != null && authHeader.StartsWith("Password", StringComparison.OrdinalIgnoreCase))
        {
            var password = authHeader.Substring("Password ".Length).Trim();

            string hashedInput = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: Convert.FromBase64String(salt),
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));

            // Nu tjekkes om password er korrekt
            if (hashedInput == hashedAdmin)
            {
                // Vi opretter et "claim"
                var claims = new[] { new Claim("Role", "Admin") };
                var identity = new ClaimsIdentity(claims);
                var claimsPrincipal = new ClaimsPrincipal(identity);

                // Claim returneres og giver nu adgang til endpoints der i deres 
                // policty har "Role = Admin".
                return Task.FromResult(AuthenticateResult.Success(
                    new AuthenticationTicket(claimsPrincipal, "DummyAuthentication")));
            }
            else if (hashedInput == hashedCake)
            {
                // Vi opretter et "claim"
                var claims = new[] { new Claim("Role", "CakeLover") };
                var identity = new ClaimsIdentity(claims);
                var claimsPrincipal = new ClaimsPrincipal(identity);

                // Claim returneres og giver nu adgang til endpoints der i deres 
                // policty har "Role = Admin".
                return Task.FromResult(AuthenticateResult.Success(
                    new AuthenticationTicket(claimsPrincipal, "DummyAuthentication")));
            }
        }
 
        Response.StatusCode = 401;
        return Task.FromResult(AuthenticateResult.Fail("Invalid Password"));  
    }
}