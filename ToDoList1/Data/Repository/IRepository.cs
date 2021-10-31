using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList1.Models;

namespace ToDoList1.Data.Repository
{
    public interface IReposiroty
    {
        IEnumerable<ToDoItem> GetAllItems();
        void AddTodo(string todoName);
        void ValueChanged(ToDoItem changedItem);
        void DeleteItem(int id);
    }
}
