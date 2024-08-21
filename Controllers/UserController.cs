using Dapper;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Data;
using ToDoAPI.DTO;
using ToDoAPI.Models;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        DataContextDapper _dapper;

        public UserController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }


        [HttpGet("")]
        public IEnumerable<User> GetUsers()
        {
            return _dapper.GetData<User>("SELECT * FROM Users");
        }

        [HttpGet("{userId}")]
        public User GetUser(int userId)
        {
            string sql = "SELECT * FROM Users WHERE Id = @UserIdParam";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserIdParam", userId);

            return _dapper.GetDataSingleWithParams<User>(sql, parameters);
        }

        [HttpPost("")]
        public IActionResult PostUser(UserDTO user)
        {
            string sql = @"INSERT INTO Users(
                      FirstName,
                      LastName,
                      Email) VALUES(
                      @FirstName,
                      @LastName,
                      @Email)";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@FirstName", user.FirstName);
            parameters.Add("@LastName", user.LastName);
            parameters.Add("@Email", user.Email);



            if (_dapper.ExecuteSqlParams(sql, parameters)) return Ok(user);

            return BadRequest("Failed to create User");
        }
        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            string sql = "DELETE FROM Users WHERE Id = @UserId";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserId", userId);
            if (_dapper.ExecuteSqlParams(sql, parameters)) return Ok("User deleted");
            return BadRequest("Failed to delete user");
        }
    }
}
