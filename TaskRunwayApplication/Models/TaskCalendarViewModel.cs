using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskRunwayApplication.Models
{
    public class TaskCalendarViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
    }
}