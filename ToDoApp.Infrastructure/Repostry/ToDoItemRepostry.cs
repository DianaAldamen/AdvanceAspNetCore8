using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs;
using ToDoApp.Application.Interfaces;
using ToDoApp.Domain.Entity;
using ToDoApp.Infrastructure.Data;

namespace ToDoApp.Infrastructure.Repostry
{
    public class ToDoItemRepostry : IToDoRepositry
    {
        private readonly AppDbContext _context;

        public ToDoItemRepostry(AppDbContext context)
        {
            _context = context;
        }

        public ToDoAppItem Create(ToDoAppItem dTO)
        {
            _context.Add(dTO);
            _context.SaveChanges();
            return dTO;
        }

        public bool Delete( int id)
        {
            var result = _context.toDoItemDTOs.Find(id);
            _context.Remove(GetById(id));
            _context.SaveChanges(); 
            if (result != null)
            {
                return true;
            }
            return false;        }

        public List<ToDoAppItem> GetAll()
        {
            return _context.toDoItemDTOs.ToList();
        }

        public ToDoAppItem GetById(int id)
        {

            //return _context.toDoItemDTOs.Find(id);
            return _context.toDoItemDTOs.FirstOrDefault(i => i.Id == id);
        }
        public List<ToDoAppItem> Search(string item)
        {
            return _context.toDoItemDTOs.Where(i =>EF.Functions.Like(i.Title,$"%{item}%") i.Description.Contains(item)).ToList();
        }
        
        public bool Update(UpdateToDoItem item, int id )
        {
         var ToDoItem = _context.toDoItemDTOs.Find(id);
            if (ToDoItem != null)
            {
                //ToDoItem.Title = item.Title;
                //ToDoItem.Description = item.Description;
                //ToDoItem.Tags = item.Tags;
                //ToDoItem.PriorityLevel = item.PriorityLevel;
                //ToDoItem.DueDate = item.DueDate;
                ToDoItem.IsComplete = true;
            }
            _context.SaveChanges();
            return true;    
        }
        public bool UpdateComplete(UpdateCompleteDTO status, int id )
        {
         var ToDoItem = _context.toDoItemDTOs.Find(id);
            if (ToDoItem != null)
            {
                ToDoItem.IsComplete = status.item;
            }
            _context.SaveChanges();
            return true;    
        }
    }
}
