using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskFlow.API.Models;

namespace TaskFlow.API.Dtos.Task
{
    public  class TaskDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        //public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}