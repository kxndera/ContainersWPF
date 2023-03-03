using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ToDoList.Task
{
    internal class TaskName : BindableObject 
    {
        public string NameOfTask { get; set; }
        
        public bool IsCompleted { get; set; }
        public string StateOfaTask { get; set;  }

    }
}
