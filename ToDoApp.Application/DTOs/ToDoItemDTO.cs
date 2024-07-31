using System;
using System.Collections.Generic;
using ToDoApp.Domain.Enum;


namespace ToDoApp.Application.DTOs
{
    public class CreateToDoItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string UserId { get; set; }
        public List<string> Tags { get; set; }
        public PriorityLevel PriorityLevel { get; set; }


    }
    public class ToDoItemDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string UserId { get; set; }
        public List<string> Tags { get; set; }
        public PriorityLevel PriorityLevel { get; set; }


    } 
    public class UpdateToDoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string UserId { get; set; }
        public List<string> Tags { get; set; }
        public PriorityLevel PriorityLevel { get; set; }
        //public bool IsComplete { get; set; }


    }
}