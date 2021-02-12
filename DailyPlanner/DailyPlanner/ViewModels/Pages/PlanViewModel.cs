using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DailyPlanner
{
    public class PlanViewModel : BaseViewModel
    {
        #region Public Properties

        public bool AdditionButtonVisible { get; set; } = true;

        public int TotalTasks { get; set; }

        public TimeSpan TotalPlannedTime { get; set; }

        public ObservableCollection<TaskItem> TaskItems { get; set; }

        #endregion

        #region Commands

        public ICommand AddTaskCommand { get; set; }

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

        public override Task InitializeAsync(object navigationData = null)
        {
            TaskItems = new ObservableCollection<TaskItem>();
            TotalPlannedTime = new TimeSpan(); 
            return base.InitializeAsync(navigationData);
        }

        #region Command Methods

        private void AddTask()
        {
            AdditionButtonVisible = false;
        }

        #endregion

        #region Private Methods

        private void InitializeCommands()
        {
            AddTaskCommand = new RelayCommand(AddTask);
        }
        
        #endregion
    }
}
