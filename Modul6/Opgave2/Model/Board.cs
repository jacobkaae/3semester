using System;
using System.Collections.Generic;

namespace Opgave1.Model
{
    public class Board
    {
        public Board()
        {

        }

        public Board(List<ToDo> toDo)
        {
            this.Todo = toDo;
        }
        public long BoardId { get; set; }
        public List<ToDo> Todo { get; set; } = new List<ToDo>();
    }
}

