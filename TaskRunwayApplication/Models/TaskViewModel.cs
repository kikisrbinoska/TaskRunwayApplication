using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskRunwayApplication.Models
{
    public class TaskViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string UserId { get; set; }
        public TimeSpan? TimeSpent { get; set; }

        public TaskStatus TaskStatus { get; set; }
        public int? CategoryId { get; set; }
        public string NewCategoryName { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}