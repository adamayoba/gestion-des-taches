using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskFlow.API.Dtos.Task;
using TaskFlow.API.Models;

namespace TaskFlow.API.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task<TaskItem?> GetByIdAsync(int id);
        Task<TaskItem?> UpdateAsync(int id, UpdateTaskRequestDTO newTask);
        Task<TaskItem?> DeleteAsync(int id);
        Task<TaskItem> CreateAsync(TaskItem task);
        Task<bool> IsExist(int id);
    }
}