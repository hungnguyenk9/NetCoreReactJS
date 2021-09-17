using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NetCoreReactJS.Common;
using NetCoreReactJS.Models;
using NetCoreReactJS.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace NetCoreReactJS.Query.ClientUserQuery
{
    public class ClientUserQueryService : IClientUserQueryService
    {
        private readonly AppSettings _appSettings;
        private readonly IConnectionService _connection;
        public ClientUserQueryService(IOptions<AppSettings> appSettings, IConnectionService connection)
        {
            _appSettings = appSettings.Value;
            _connection = connection;
        }
        public int Authenticate(string email, string password)
        {
            try
            {
                using (IDbConnection conn = _connection.GetConnection())
                {
                    password = HashMD5.GetMd5Hash(password);
                    string SqlQuery = @"
                    select COUNT(*) 
                    from CLIENT_USER
                    where [Email] = @Email and [Password] = @Password
                    ";
                    var param = new DynamicParameters();
                    param.Add("@Email", email, DbType.String);
                    param.Add("@Password", password, DbType.String);
                    int kq = conn.ExecuteScalar<int>(SqlQuery, param, commandType: CommandType.Text);
                    return kq;
                }
            }
            finally
            {
                _connection.CloseConnection();
            }
        }

        public ClientUser GetOneByEmail(string email)
        {
            try
            {
                using (IDbConnection conn = _connection.GetConnection())
                {
                    string SqlQuery = @"
                    select * 
                    from CLIENT_USER
                    where [Email] = @Email
                    ";
                    var param = new DynamicParameters();
                    param.Add("@Email", email, DbType.String);
                    ClientUser kq = conn.ExecuteScalar<ClientUser>(SqlQuery, param, commandType: CommandType.Text);
                    return kq;
                }
            }
            finally
            {
                _connection.CloseConnection();
            }
        }

        public AuthRes GetToken(string email, string password )
        {
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.NameIdentifier, password)
                }),
                Expires = DateTime.UtcNow.AddMinutes(_appSettings.Expiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            AuthRes authRespone = new AuthRes()
            {
                Token = tokenHandler.WriteToken(token),
                Expiration = tokenDescriptor.Expires,
                Email = email
            };
            return authRespone;
        }
    }
}
