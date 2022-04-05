using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIT.Model
{
    public class ToDo
    {
        private readonly int _todoId;
        private string _description;
        private bool _done;
        private Person _assignee;
        public int todoID { get  => _todoId;}
        public string description { get => _description; }


        public ToDo(int todoIt, string description) {
            _todoId = todoIt;
            _description = description;
        }
    }

    
}
