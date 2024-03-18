using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Tourplanner.Models;

namespace Tourplanner.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly EditorBarViewModel editorBarViewModel;

        private TaskModel selectedTask;

        public TaskModel SelectedTask
        {
            get { return selectedTask; }
            set
            {
                selectedTask = value;
                editorBarViewModel.SelectedTask = value;
            }
        }

        public ObservableCollection<TaskModel> Tasks { get; } = new ObservableCollection<TaskModel>()
        {
            new TaskModel() { Name = "Task 1", DueDate = DateTime.Now, IsComplete = true },
            new TaskModel() { Name = "Task 2", DueDate = DateTime.Now, IsComplete = false },
        };


        public MainViewModel(EditorBarViewModel editorBarViewModel)
        {
            this.editorBarViewModel = editorBarViewModel;

            editorBarViewModel.AddButtonClicked += (sender, task) =>
            {
                Debug.Print("Adding new task: " + task.Name);
                Tasks.Add(task);
                OnPropertyChanged(nameof(Tasks));

                editorBarViewModel.NewTaskName = "";
            };

            editorBarViewModel.DeleteButtonClicked += (sender, task) =>
            {
                Debug.Print($"Deleting task: {task?.Name}");
                if (task != null)
                    Tasks.Remove(task);
                OnPropertyChanged(nameof(Tasks));
            };
        }

        public MainViewModel()  // only necessary for the designer
        {
            this.editorBarViewModel = new EditorBarViewModel();
        }
    }
}
