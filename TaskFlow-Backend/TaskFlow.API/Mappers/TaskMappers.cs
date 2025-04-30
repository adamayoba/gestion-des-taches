using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.SwaggerGen;
using TaskFlow.API.Dtos.Task;
using TaskFlow.API.Models;

namespace TaskFlow.API.Mappers
{
    public static class TaskMappers
    {
        public static TaskDTO ToTaskDTO(this TaskItem task)
        {
            return new TaskDTO()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted
            };
        }

        public static TaskItem ToTaskFromCreateTaskDTO(this CreateTaskRequestDTO taskDTO)
        {
            return new TaskItem()
            {
                Title = taskDTO.Title,
                Description = taskDTO.Description,
            };
        }

        public static TaskItem ToTaskFromUpdateTaskDTO(this UpdateTaskRequestDTO taskDTO, TaskItem task)
        {
                task.Title = taskDTO.Title;
                task.Description = taskDTO.Description;
                task.IsCompleted = taskDTO.IsCompleted;

            return task;
        }
    }
}