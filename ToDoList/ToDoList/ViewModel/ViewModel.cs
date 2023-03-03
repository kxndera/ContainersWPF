using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using ToDoList.Task;
using Xamarin.Forms;
using System.Collections.Specialized;

namespace ToDoList.ViewModel
{
    internal class ViewModel : BindableObject
    {
        public ObservableCollection<TaskName> CollectionOfTasks { get; set; }
        public ObservableCollection<TaskName> CollectionOfDeletedTasks { get; set; }

        private string newTaskName;
        public string NewTaskName
        {
            get { return newTaskName; }
            set
            {
                newTaskName = value;
                OnPropertyChanged();
                
            }
        }
        // <ListView ItemsSource="{Binding CollectionOfTasks}" HasUnevenRows="True"
       // SelectedItem="{Binding SelectedTask}">


        //private TaskName selectedTask;
        //public TaskName SelectedTask
        //{
        //    get { return selectedTask; }
        //    set
        //    {
        //        selectedTask = value;
        //    }
        //}


        private ICommand addNewTask;
        public ICommand AddNewTask
        {
            get
            {
                if (addNewTask == null)
                    addNewTask = new Command<object>(
                        o =>
                        {
                           TaskName taskName =  new TaskName();
                            taskName.NameOfTask = NewTaskName;
                            CollectionOfTasks.Add(taskName);
                        }
                        );
                return addNewTask;
            }
        }


        private ICommand deleteTask;
        public ICommand DeleteTask
        {
            get
            {
                if (deleteTask == null)
                    deleteTask = new Command<TaskName>(
                        o =>
                        {
                            //jak cos to odwroc cepie
                            // CollectionOfDeletedTasks.Add(SelectedTask);
                            // CollectionOfTasks.Remove(SelectedTask);
                            TaskName deletedTaskName = new TaskName();
                            deletedTaskName.NameOfTask = o.NameOfTask;
                            deletedTaskName.StateOfaTask = o.StateOfaTask;
                            CollectionOfDeletedTasks.Add(deletedTaskName);
                            CollectionOfTasks.Remove(o);
                        }
                        );
                return deleteTask;
            }
        }

        public ViewModel()
        {
            CollectionOfTasks = new ObservableCollection<TaskName>();    
            CollectionOfDeletedTasks = new ObservableCollection<TaskName>();
        }
    }
}
