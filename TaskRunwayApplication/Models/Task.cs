using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskRunwayApplication.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string UserId { get; set; }


        public int Spent { get; set; }
        public TaskStatus TaskStatus { get; set; }

        public string Category { get; set; }


    }
}