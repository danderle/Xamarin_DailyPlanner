using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DailyPlanner
{
    /// <summary>
    /// The view model for the <see cref="PlanPage"/>
    /// </summary>
    public class PlanViewModel : BaseViewModel
    {
        #region Fields

        private int editingIndex = -1;

        #endregion

        #region Public Properties

        public bool TaskItemSetupIsVisible { get; set; } = false;

        public bool AdditionButtonVisible { get; set; } = true;

        public bool OverlayIsVisible { get; set; } = false;

        public int TotalTasks { get; set; } = 0;

        public TimeSpan TotalPlannedTime { get; set; } = new TimeSpan();

        public TaskItemSetupViewModel TaskItemSetup { get; set; } = new TaskItemSetupViewModel();

        public ObservableCollection<TaskItemViewModel> TaskItems { get; set; } = new ObservableCollection<TaskItemViewModel>();

        #endregion

        #region Commands

        public ICommand AddTaskCommand { get; set; }

        public ICommand SaveCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// 
        /// </summary>
        public PlanViewModel()
        {
            InitializeCommands();
            TaskItemViewModel.ItemTrashed += OnItemTrashed;
            TaskItemViewModel.ItemEdit += OnItemEdit;
        }

        #endregion

        #region Event Handlers

        private void OnItemTrashed()
        {
            var itemToDelete = TaskItems.First(t => t.TrashItem == true);
            var index = TaskItems.IndexOf(itemToDelete);
            if (index > -1)
            {
                TaskItems.RemoveAt(index);
            }
        }

        private void OnItemEdit()
        {
            var itemToEdit = TaskItems.First(t => t.EditItem == true);
            if (itemToEdit != null)
            {
                TaskItemSetup = new TaskItemSetupViewModel(itemToEdit);
                TaskItemSetupIsVisible = true;
                editingIndex = TaskItems.IndexOf(itemToEdit);
            }
        }

        #endregion

        #region Command Methods

        private void Save()
        {
            if(editingIndex > -1)
            {
                TaskItems.RemoveAt(editingIndex);
                editingIndex = -1;
            }

            TaskItemSetupIsVisible = false;
            OverlayIsVisible = false;
            AdditionButtonVisible = true;
            TaskItemViewModel item = TaskItemSetup.GetTaskItem();
            TotalPlannedTime += item.TimeToComplete;
            TaskItems.Add(item);
            TotalTasks++;
            //Sort the items according to start time
            TaskItems = new ObservableCollection<TaskItemViewModel>(TaskItems.OrderBy(t => t.StartTime));
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
        }

        #endregion
    }
}
