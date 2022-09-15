using System;
namespace Opgave8.Model
{
    public class Task
    {

        public Task(string text, bool done)
        {
            this.Text = text;
            this.Done = done;
        }

        public long TaskId { get; set; }
        public string Text { get; set; }
        public bool Done { get; set; }
    }
}