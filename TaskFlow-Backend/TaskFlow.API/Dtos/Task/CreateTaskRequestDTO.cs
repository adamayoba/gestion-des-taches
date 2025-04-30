using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskFlow.API.Dtos.Task
{
    public class CreateTaskRequestDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        //public DateTime DueDate { get; set; }
       // public bool IsCompleted { get; set; } = false;
    }
}