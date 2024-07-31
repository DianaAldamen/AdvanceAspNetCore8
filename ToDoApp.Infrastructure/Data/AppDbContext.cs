using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Application.DTOs;
using ToDoApp.Domain.Entity;

namespace ToDoApp.Infrastructure.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        } 
        //protected override void OnNodeCreating(ModelBuilder modelbuilder)
        //{
        //    modelbuilder.Entity<ToDoAppItem>().HasQueryFilter(i=>i.Title.Equals("Dia"));
        //    base.OnModelCreating(modelbuilder);
        //}
        public DbSet<ToDoAppItem> toDoItemDTOs { get; set; }    
    }
}
