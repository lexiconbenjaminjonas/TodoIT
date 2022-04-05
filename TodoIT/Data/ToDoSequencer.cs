using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIT.Data
{
    class ToDoSequencer
    {
        private static int _toDoId;
        public static int ToDoId { get => _toDoId; }

        public static int nextToDoId()
        {
            return _toDoId++;
        }

        public static void reset()
        {
            _toDoId = 0;
        }
    }

    
}
