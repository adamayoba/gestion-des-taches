using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.API.Dtos.Task;
using TaskFlow.API.Interfaces;
using TaskFlow.API.Mappers;

namespace TaskFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequireUserRole")]
    public class TaskController : ControllerBase
    {
        //private readonly AppDbContext _context;
        private readonly ITaskRepository _repository;

        public TaskController(ITaskRepository repository)
        {
           // _context = context;
            _repository = repository;
        }
        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskDTO>>> GetTasks()
        {
            var tasks = await _repository.GetAllAsync();  
            var taskDTO = tasks.Select(x => x.ToTaskDTO());
            return Ok(taskDTO);      
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDTO>> GetTask([FromRoute] int id)
        {
            var task = await _repository.GetByIdAsync(id);

            if (task == null) return NotFound();

            return Ok(task.ToTaskDTO());
        }

        [HttpPost]
        public async Task<ActionResult<TaskDTO>> CreateTask([FromBody] CreateTaskRequestDTO taskDTO)
        {
            var taskModel = taskDTO.ToTaskFromCreateTaskDTO();
            await _repository.CreateAsync(taskModel);

            return CreatedAtAction(nameof(GetTask),new { id = taskModel.Id }, taskModel.ToTaskDTO());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTask([FromRoute] int id,[FromBody] UpdateTaskRequestDTO newTask)
        {
            var task = await _repository.UpdateAsync(id,newTask);

            if (task == null) return NotFound();

            return NoContent();
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask([FromRoute]int id)
        {
            var task = await _repository.DeleteAsync(id);

            if (task == null) return NotFound();

            return NoContent();
        }
    }
}