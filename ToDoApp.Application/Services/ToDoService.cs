using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs;
using ToDoApp.Application.Interfaces;
using ToDoApp.Domain.Entity;

namespace ToDoApp.Application.Services
{
    public class ToDoService
    {
        private readonly IToDoRepositry _repositry;
        public ToDoService(IToDoRepositry repositry)
        {
            _repositry = repositry;
            
        }

        public List<ToDoItemDTO> GetAll()
        {
            var result = _repositry.GetAll();
            //var mappedresult = result.Select(TODItem => new ToDoItemDTO() {
            // Description = TODItem.Description , 
            //Title = TODItem.Title,
            //DueDate = TODItem.DueDate,
            //Id = TODItem.Id,
            //PriorityLevel = TODItem.PriorityLevel,
            //Tags = TODItem.Tags,
            //UserId = TODItem.UserId}).ToList();
            var mappedresult = result.Adapt<List< ToDoItemDTO>>();
            return mappedresult;
        }
        public List<ToDoItemDTO> Search(string item)
        {
            var result = _repositry.Search(item);
            //var mappedresult = result.Select(TODItem => new ToDoItemDTO() {
            // Description = TODItem.Description , 
            //Title = TODItem.Title,
            //DueDate = TODItem.DueDate,
            //Id = TODItem.Id,
            //PriorityLevel = TODItem.PriorityLevel,
            //Tags = TODItem.Tags,
            //UserId = TODItem.UserId}).ToList();
            var mappedresult = result.Adapt<List< ToDoItemDTO>>();
            return mappedresult;
        }
        public ToDoItemDTO GetById(int id)
        {
           var ToDoItem= _repositry.GetById(id);

            
            return ToDoItem.Adapt<ToDoItemDTO>();
        }
        public bool UpdateById(int id,UpdateToDoItem dto)
        {
            var  result=_repositry.Update(dto,id);
            return result;
        }
        public bool UpdateComplete(UpdateCompleteDTO dto)
        {
            var result = _repositry.UpdateComplete(dto);
            return result;
        }
        public bool DeleteById(int id)
        {
            var  result=_repositry.Delete(id);
            return result;
        }
        public ToDoItemDTO Create(CreateToDoItem dto)
        {
            var todoItem = dto.Adapt<ToDoAppItem>();    
            _repositry.Create(todoItem);
            return todoItem.Adapt<ToDoItemDTO>();
        }
    }
}
