using Dapper;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Data;
using ToDoAPI.DTO;
using ToDoAPI.Models;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        DataContextDapper _dapper;

        public TaskController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }

        [HttpGet("TestConnection")]
        public DateTime TestConnection()
        {
            return _dapper.GetDataSingle<DateTime>("SELECT GETDATE()");
        }

        [HttpGet("")]
        public IEnumerable<Models.Task> GetTasks()
        {
            return _dapper.GetData<Models.Task>("SELECT * FROM Tasks");
        }

        [HttpGet("{taskId}")]
        public Models.Task GetTask(int taskId)
        {
            string sql = "SELECT * FROM Tasks WHERE Id = @TaskIdParam";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("TaskIdParam", taskId);

            return _dapper.GetDataSingleWithParams<Models.Task>(sql, parameters);
        }

        [HttpPost("")]
        public IActionResult PostTask(TaskDTO task)
        {
            string sql = @"INSERT INTO Tasks(
                      Title,
                      Description,
                      StartDate,
                      EndDate,
                      ProjectId,
                      AssignedUserId) VALUES(
                      @TitleParam,
                      @DescriptionParam,
                      @StartDateParam,
                      @EndDateParam,
                      @ProjectIdParam,
                      @AssignedUserIdPram)";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("TitleParam", task.Title);
            parameters.Add("DescriptionParam", task.Description);
            parameters.Add("StartDateParam", task.StartDate);
            parameters.Add("EndDateParam", task.EndDate);
            parameters.Add("ProjectIdParam", task.ProjectId);
            parameters.Add("AssignedUserIdPram", task.AssignedUserId);


            if (_dapper.ExecuteSqlParams(sql, parameters)) return Ok(task);

            return BadRequest("Failed to create Task");
        }
    }
}
