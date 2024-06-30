using IMS.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMS.Web.API
{
    [Route("ims/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private IConfiguration _configuration;

        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET: api/<AuthenticationController>
        [Authorize]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "jok", "admin@12345" };
        }

        // GET api/<AuthenticationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuthenticationController>
        [AllowAnonymous]
        [HttpPost("[action]")]
        public IActionResult Login([FromBody] UserViewModel userViewModel)
        {
            try
            {
                var user = Authenticate(userViewModel);

                if(user != null)
                {
                    var token = GenerateToken(user);
                    return Ok(token);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return NotFound("usernot found");
        }

        // PUT api/<AuthenticationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthenticationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        #region private methods
        private UserViewModel Authenticate(UserViewModel user)
        {
            try
            {
                //Check in Database
                //If found return user
                return user;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        private string GenerateToken(UserViewModel user)
        {
            try
            {
                //Declare settings values
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                //Define Claim Properties
                var claims = new[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                };

                //Define JwtSecurityToken
                var token = new JwtSecurityToken
                    (
                        _configuration["JwtSettings:Issuer"],
                        _configuration["JwtSettings:Audience"],
                        claims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: credentials
                    );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }

        }
        #endregion
    }
}
