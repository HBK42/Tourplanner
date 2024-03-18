using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Tourplanner.Models;

namespace Tourplanner.ViewModels
{
    public class EditorBarViewModel : INotifyPropertyChanged
    {
        private string newTaskName = "New Task";

        public string NewTaskName
        {
            get { return newTaskName; }
            set
            {
                newTaskName = value;
                OnPropertyChanged(nameof(NewTaskName));
                AddNewTaskCommand.RaiseCanExecuteChanged();
            }
        }

        private TaskModel selectedTask;

        public TaskModel SelectedTask
        {
            get { return selectedTask; }
            set
            {
                selectedTask = value;
                DeleteTaskCommand.RaiseCanExecuteChanged();
            }
        }

        public RelayCommand AddNewTaskCommand { get; }
        public RelayCommand DeleteTaskCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler<TaskModel> AddButtonClicked;

        public event EventHandler<TaskModel> DeleteButtonClicked;

        public EditorBarViewModel()
        {
            AddNewTaskCommand = new RelayCommand((_) =>
            {
                AddButtonClicked?.Invoke(this, new TaskModel() { Name = NewTaskName, DueDate = DateTime.Now, IsComplete = false });
            }, (_) => !string.IsNullOrWhiteSpace(NewTaskName));

            DeleteTaskCommand = new RelayCommand((_) =>
            {
                DeleteButtonClicked?.Invoke(this, SelectedTask);
            }, (_) => SelectedTask != null);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
