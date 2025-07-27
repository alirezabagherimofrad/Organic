using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.IdentityModel.Tokens;
using Organic.Application.DTO;
using Organic.Application.Interface;
using Organic.Domain.Interface.UserInterfase;
using Organic.Infrastructure.Settings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Application.Service
{
    public class JwtService : IJwtService
    {
        private readonly JwtSettings _jwtSettings;

        private readonly IGetUserQueryRepository _getUserQueryRepository;

        public JwtService(JwtSettings jwtSettings, IGetUserQueryRepository getUserQueryRepository)
        {
            _jwtSettings = jwtSettings;

            _getUserQueryRepository = getUserQueryRepository;
        }

        public async Task<string> GeneratToken(Guid userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);

            var user = await _getUserQueryRepository.GetByIdAsync(userId);

            if (user == null)
                throw new Exception("User Not Found");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,userId.ToString()),

                new Claim(ClaimTypes.Name,$"{user.First_Name} {user.Last_Name}"),

                new Claim (ClaimTypes.Email,user.Email),

                new Claim (ClaimTypes.MobilePhone,user.PhoneNumber),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),

                Expires = DateTime.UtcNow.AddMinutes(15),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
