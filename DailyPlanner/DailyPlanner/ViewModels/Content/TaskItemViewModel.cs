using System;
using System.Windows.Input;

namespace DailyPlanner
{

    public class TaskItemViewModel : BaseViewModel
    {
        #region Public Properties

        public bool TrashItem { get; set; } = false;

        public bool DeleteVisible { get; set; } = false;

        public string TaskToComplete { get; set; }
        
        public TimeSpan StartTime { get; set; }

        public TimeSpan TimeToComplete { get; set; }

        public static event Action ItemTrashed;

        #endregion

        #region Commands

        public ICommand OpenDeleteCommand { get; set; }

        public ICommand CloseDeleteCommand { get; set; }

        public ICommand TrashCommand { get; set; }

        #endregion

        #region Constructor

        public TaskItemViewModel()
        {
            InitializeCommands();
        }

        #endregion

        #region Commands Methods

        private void OpenDelete()
        {
            DeleteVisible = true;
        }

        private void CloseDelete()
        {
            DeleteVisible = false;
        }

        private void Trash()
        {
            TrashItem = true;
            ItemTrashed?.Invoke();
        }

        #endregion

        #region Private Methods

        private void InitializeCommands()
        {
            OpenDeleteCommand = new RelayCommand(OpenDelete);
            CloseDeleteCommand = new RelayCommand(CloseDelete);
            TrashCommand = new RelayCommand(Trash);
        }

        #endregion
    }
}
