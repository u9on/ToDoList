using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList1.Models;

namespace ToDoList1.Data.Repository
{
    public class SQLRepository : IReposiroty
    {
        private readonly DB _context;
        public SQLRepository(DB context)
        {
            _context = context;
        }

        public void AddTodo(string todoName)
        {
            ToDoItem newItem = new ToDoItem()
            {
                Title = todoName,
                IsDone = false
            };

            _context.ToDoItems.Add(newItem);
            _context.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            var deleteItem = _context.ToDoItems.Find(id);

            if(deleteItem != null)
            {
                _context.ToDoItems.Remove(deleteItem);
                _context.SaveChanges();
            }
        }

        public IEnumerable<ToDoItem> GetAllItems()
        {
            return _context.ToDoItems;
        }

        public void ValueChanged(ToDoItem changedItem)
        {
            var item = _context.ToDoItems.Attach(changedItem);
            item.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _context.SaveChanges();
        }
    }
}
