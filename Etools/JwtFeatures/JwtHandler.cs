using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Etools.JwtFeatures
{
    public class JwtHandler
    {
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _jwtSettings;
        private readonly IConfigurationSection _goolgeSettings;
        public JwtHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _jwtSettings = _configuration.GetSection("JWT");
        }
        //private async Task<List<Claim>> GetClaims(ApplicationUser user)
        //{
        //    var roles = await userManager.GetRolesAsync(user);

        //    var claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Name, user.Email),
        //        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
        //    };

        //    foreach (var role in roles)
        //    {
        //        claims.Add(new Claim(ClaimTypes.Role, role));
        //    }

        //    return claims;
        //}


        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("Secret").Value);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }



        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtSettings.GetSection("ValidIssuer").Value,
                audience: _jwtSettings.GetSection("ValidAudience").Value,
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signingCredentials);

            return tokenOptions;
        }

        //public async Task<string> GenerateToken(ApplicationUser user)
        //{
        //    var signingCredentials = GetSigningCredentials();
        //    var claims = await GetClaims(user);
        //    var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
        //    var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        //    return token;
        //}
    }
}
