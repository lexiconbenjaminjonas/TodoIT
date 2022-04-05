using System;
using System.Collections.Generic;
using System.Text;
using TodoIT.Model;

namespace TodoIT.Data
{
    class ToDoItems
    {
        private static ToDo[] _toDoItem = new ToDo[0];

        public int Size()
        {
            return _toDoItem.Length;
        }

        public ToDo[] FindAll()
        {
            return _toDoItem;
        }
        public ToDo FindById(int itemId)
        {
            foreach (var item in _toDoItem)
            {
                if (item.todoID == itemId)
                {
                    return item;
                }
            }
            return null;
        }

        public ToDo CreateToDo(string description)
        {
            ToDo t = new ToDo(ToDoSequencer.nextToDoId(), description);
            Array.Resize(ref _toDoItem, _toDoItem.Length + 1);
            _toDoItem[_toDoItem.Length - 1] = t;
            return t;
        }

        public void Clear()
        {
            Array.Clear(_toDoItem, 0, _toDoItem.Length);
        }
    }
}
