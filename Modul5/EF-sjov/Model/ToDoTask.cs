using System;
namespace EF_sjov.Model
{
    public class TodoTask
    {
        public TodoTask(string text, bool done, string category, User bruger)
        {
            this.Text = text;
            this.Done = done;
            this.Category = category;
            this.Bruger = bruger;
        }

        public TodoTask(string text, bool done, string category)
        {
            this.Text = text;
            this.Done = done;
            this.Category = category;
        }

        public long TodoTaskId { get; set; }
        public string? Text { get; set; }
        public bool Done { get; set; }
        public string? Category { get; set; }
        public User Bruger { get; set; }
    }
}