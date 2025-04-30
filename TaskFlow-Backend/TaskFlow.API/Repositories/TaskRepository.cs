using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TaskFlow.API.Data;
using TaskFlow.API.Dtos.Task;
using TaskFlow.API.Interfaces;
using TaskFlow.API.Mappers;
using TaskFlow.API.Models;

namespace TaskFlow.API.Repositories
{
  public class TaskRepository : ITaskRepository
  {
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TaskItem> CreateAsync(TaskItem task)
    {
      await _context.Tasks.AddAsync(task);
      await _context.SaveChangesAsync();

      return task;
    }

    public async Task<TaskItem?> DeleteAsync(int id)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(x => id == x.Id);
        if (task == null) return null;

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();

        return task;
    }

    public async Task<IEnumerable<TaskItem>> GetAllAsync()
    {
      return await _context.Tasks.ToListAsync();
    }

    public async Task<TaskItem?> GetByIdAsync(int id)
    {
        return await _context.Tasks.FirstOrDefaultAsync(t => id == t.Id);
    }

    public async Task<bool> IsExist(int id)
    {
      return await _context.Tasks.AnyAsync(t => id == t.Id);
    }

    public async Task<TaskItem?> UpdateAsync(int id, UpdateTaskRequestDTO newTask)
    {
      var oldTask = await _context.Tasks.FirstOrDefaultAsync(t => id == t.Id);

      if (oldTask == null) return null;

      var task = newTask.ToTaskFromUpdateTaskDTO(oldTask);

      await _context.SaveChangesAsync();

      return task;
    }
  }
}