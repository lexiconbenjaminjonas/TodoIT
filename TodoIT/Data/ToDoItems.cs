using System;
using System.Collections.Generic;
using System.Text;
using TodoIT.Model;
using System.Linq;

namespace TodoIT.Data
{
    public class ToDoItems
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

        public ToDo CreateToDo(string description, Person assignee)
        {
            ToDo t = new ToDo(ToDoSequencer.nextToDoId(), description);
            t.assignee = assignee;
            Array.Resize(ref _toDoItem, _toDoItem.Length + 1);
            _toDoItem[_toDoItem.Length - 1] = t;
            return t;
        }

        public void Clear()
        {
            Array.Resize(ref _toDoItem,0);
        }

        public ToDo[] FindByDoneStatus(bool doneStatus)
        {
            List <ToDo> returnList = new List<ToDo>();
            if (doneStatus)
            {
                foreach (ToDo c in _toDoItem.Where(c => c.done))
                {
                    returnList.Add(c);
                }
            }else
            {
                foreach (ToDo c in _toDoItem.Where(c => !c.done))
                {
                    returnList.Add(c);
                }
            }
            
            return returnList.ToArray();
        }
        
        public ToDo[] FindByAssignee(int personId)
        {
            List<ToDo> returnList = new List<ToDo>();
            foreach (ToDo c in _toDoItem.Where(c => c.assignee.PersonId==personId))
            {
                returnList.Add(c);
            }
            return returnList.ToArray();
        }

        public ToDo[] FindByAssignee(Person assignee)
        {
            List<ToDo> returnList = new List<ToDo>();
            foreach (ToDo c in _toDoItem.Where(c => c.assignee == assignee))
            {
                returnList.Add(c);
            }
            return returnList.ToArray();
        }

        public ToDo[] FindUnassignedTodoItems()
        {
            List<ToDo> returnList = new List<ToDo>();
            foreach (ToDo c in _toDoItem.Where(c => c.assignee == null))
            {
                returnList.Add(c);
            }
            return returnList.ToArray();
        }
    }
}
