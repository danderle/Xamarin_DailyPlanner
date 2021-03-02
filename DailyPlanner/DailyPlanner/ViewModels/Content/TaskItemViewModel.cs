using System;
using System.Windows.Input;

namespace DailyPlanner
{
    /// <summary>
    /// The view model for the <see cref="TaskItemContent"/>
    /// </summary>
    public class TaskItemViewModel : BaseViewModel
    {
        #region Public Properties

        public bool TrashItem { get; set; } = false;

        public bool EditItem { get; set; } = true;

        public bool TrashEditVisible { get; set; } = false;

        public string TaskToComplete { get; set; }
        
        public TimeSpan StartTime { get; set; }

        public TimeSpan TimeToComplete { get; set; }

        public static event Action ItemTrashed;

        public static event Action ItemEdit;

        #endregion

        #region Commands

        public ICommand OpenDeleteCommand { get; set; }

        public ICommand CloseDeleteCommand { get; set; }

        public ICommand TrashCommand { get; set; }

        public ICommand EditCommand { get; set; }

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
            TrashEditVisible = true;
        }

        private void CloseDelete()
        {
            TrashEditVisible = false;
        }

        private void Trash()
        {
            TrashItem = true;
            ItemTrashed?.Invoke();
        }

        private void Edit()
        {
            EditItem = true;
            ItemEdit?.Invoke();
        }

        #endregion

        #region Private Methods

        private void InitializeCommands()
        {
            OpenDeleteCommand = new RelayCommand(OpenDelete);
            CloseDeleteCommand = new RelayCommand(CloseDelete);
            TrashCommand = new RelayCommand(Trash);
            EditCommand = new RelayCommand(Edit);
        }

        #endregion
    }
}
