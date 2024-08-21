using Dapper;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Data;
using ToDoAPI.DTO;
using ToDoAPI.Models;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        DataContextDapper _dapper;

        public ProjectController(IConfiguration config)
        {
            _dapper = new DataContextDapper(config);
        }


        [HttpGet("")]
        public IEnumerable<Project> GetProjects()
        {
            return _dapper.GetData<Project>("SELECT * FROM Projects");
        }

        [HttpGet("{projectId}")]
        public Project GetProject(int projectId)
        {
            string sql = "SELECT * FROM Projects WHERE Id = @ProjectIdParam";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ProjectIdParam", projectId);

            return _dapper.GetDataSingleWithParams<Project>(sql, parameters);
        }

        [HttpPost("")]
        public IActionResult PostProject(ProjectDTO project)
        {
            string sql = @"INSERT INTO Projects(
                      Name,
                      Description,
                      StartDate,
                      EndDate) VALUES(
                      @Name,
                      @Description,
                      @StartDate,
                      @EndDate)";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Name", project.Name);
            parameters.Add("@Description", project.Description);
            parameters.Add("@StartDate", project.StartDate);
            parameters.Add("@EndDate", project.EndDate);


            if (_dapper.ExecuteSqlParams(sql, parameters)) return Ok(project);

            return BadRequest("Failed to create Project");
        }
        [HttpDelete("{projectId}")]
        public IActionResult DeleteProject(int projectId)
        {
            string sql = "DELETE FROM Projects WHERE Id = @ProjectId";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ProjectId", projectId);
            if (_dapper.ExecuteSqlParams(sql, parameters)) return Ok("Project deleted");
            return BadRequest("Failed to delete project");
        }
    }
}
