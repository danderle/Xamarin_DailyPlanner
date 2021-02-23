using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DailyPlanner
{
    public class PlanViewModel : BaseViewModel
    {
        #region Public Properties

        public bool TaskItemSetupIsVisible { get; set; } = false;

        public bool AdditionButtonVisible { get; set; } = true;

        public bool OverlayIsVisible { get; set; } = false;

        public int TotalTasks { get; set; } = 0;

        public TimeSpan TotalPlannedTime { get; set; } = new TimeSpan();

        public TaskItemSetupViewModel TaskItemSetup { get; set; } = new TaskItemSetupViewModel();

        public ObservableCollection<TaskItem> TaskItems { get; set; } = new ObservableCollection<TaskItem>();

        #endregion

        #region Commands

        public ICommand AddTaskCommand { get; set; }

        public ICommand SaveCommand { get; set; }

        public ICommand TrashCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        public PlanViewModel()
        {
            InitializeCommands();
        }

        #endregion

        #region Command Methods

        private void Save()
        {
            TaskItemSetupIsVisible = false;
            OverlayIsVisible = false;
            AdditionButtonVisible = true;
            TaskItem item = TaskItemSetup.GetTaskItem();
            TaskItems.Add(item);
            TotalTasks++;
            TotalPlannedTime += item.TimeToComplete;
        }

        private void Trash()
        {
            TaskItemSetupIsVisible = false;
            OverlayIsVisible = false;
            AdditionButtonVisible = true;
        }

        private void AddTask()
        {
            TaskItemSetupIsVisible = true;
            AdditionButtonVisible = false;
            OverlayIsVisible = true;
            TaskItemSetup = new TaskItemSetupViewModel();
        }

        #endregion

        #region Private Methods

        private void InitializeCommands()
        {
            AddTaskCommand = new RelayCommand(AddTask);
            SaveCommand = new RelayCommand(Save);
            TrashCommand = new RelayCommand(Trash);
        }

        #endregion
    }
}
