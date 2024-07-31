using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs;
using ToDoApp.Domain.Entity;

namespace ToDoApp.Application.Interfaces
{
    public interface IToDoRepositry
    {
        List<ToDoAppItem> GetAll();
        List<ToDoAppItem> Search(string item);
        ToDoAppItem GetById(int id);
        ToDoAppItem Create(ToDoAppItem dTO);
        bool Update(UpdateToDoItem dTO,int id);
        bool UpdateComplete(UpdateCompleteDTO item);
        bool Delete(int id);

    }
}
