using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Vizitz.Entities;
using Vizitz.Models.Account;

namespace Vizitz.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<User> _userManager;

        private readonly IConfiguration _configuration;

        private const string DEFAULT_LIFETIME = "10080";

        private const string DEFAULT_ISSUER = "Vizitz";

        private User _user;

        public AuthManager(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;

            _configuration = configuration;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();

            var claims = await GetClaims();

            var token = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> ValidateUser(LoginDTO loginDTO)
        {
            _user = await _userManager.FindByNameAsync(loginDTO.Email);

            var validPassword = await _userManager.CheckPasswordAsync(_user, loginDTO.Password);

            return (_user != null && validPassword);
        }

        public async Task<User> GetUserDetail(string userName)
        {
            //User user = await _userManager.FindByNameAsync(userName);

            return await _userManager.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.UserName == userName);
        }

        private static SigningCredentials GetSigningCredentials()
        {
            // TODO : move to secure location
            var key = "918471de-9195-457a-b1e8-08d912b91e58";

            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, _user.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier, _user.UserName),
                new Claim(ClaimTypes.Name, _user.Name),
                new Claim(ClaimTypes.MobilePhone, _user.PhoneNumber),
            };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("Jwt");

            var expiration = DateTime.Now.AddMinutes(
                Convert.ToDouble(jwtSettings.GetSection("Lifetime")?.Value ?? DEFAULT_LIFETIME)
            );

            var token = new JwtSecurityToken(
                    issuer: jwtSettings.GetSection("Issuer")?.Value ?? DEFAULT_ISSUER,
                    claims: claims,
                    expires: expiration,
                    signingCredentials: signingCredentials
            );

            return token;
        }
    }
}
