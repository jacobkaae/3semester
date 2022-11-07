using System;
namespace Opgave1.Model
{
    public class ToDo
    {
        public ToDo()
        {

        }

        public ToDo(string titel, User user)
        {
            this.Titel = titel;
            this.User = user;
        }
        public long ToDoId { get; set; }
        public string Titel { get; set; }
        public User User { get; set; }
    }
}

