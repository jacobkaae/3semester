using System;
namespace EF_sjov.Model
{
    public class User
    {
        public User(string name)
        {
            this.Name = name;
        }

        public long UserId { get; set; }
        public string Name { get; set; }
    }
}