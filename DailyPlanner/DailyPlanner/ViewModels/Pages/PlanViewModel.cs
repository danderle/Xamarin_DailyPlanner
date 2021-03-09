using System;
using System.Collections.Generic;
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

        public bool OverlayIsVisible { get; set; } = false;

        public bool DaySelectionVisible { get; set; } = false;

        public int TotalTasks { get; set; } = 0;

        public string DaysValid { get; set; } = string.Empty;

        public TimeSpan TotalPlannedTime { get; set; } = new TimeSpan();

        public TaskItemSetupViewModel TaskItemSetup { get; set; } = new TaskItemSetupViewModel();

        public ObservableCollection<TaskItemViewModel> TaskItems { get; set; } = new ObservableCollection<TaskItemViewModel>();

        public DaySelectionListViewModel DaySelectionList { get; set; } = new DaySelectionListViewModel();

        #endregion

        #region Commands

        public ICommand AddTaskCommand { get; set; }

        public ICommand SaveTaskItemCommand { get; set; }

        public ICommand TrashCommand { get; set; }

        public ICommand OpenDaySelectionCommand { get; set; }
        
        public ICommand SaveDaySelectionCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
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

        private void OpenDaySelection()
        {
            OverlayIsVisible = true;
            DaySelectionVisible = true;
        }

        private void SaveDaySelection()
        {
            DaySelectionVisible = false;
            OverlayIsVisible = false;
            var days = DaySelectionList.GetSelected();
            DaysValid = days.Count == 0 ? "Select Days" : string.Join(", ", days);
        }

        private void Trash()
        {
            TaskItemSetupIsVisible = false;
            DaySelectionVisible = false;
            OverlayIsVisible = false;
        }

        private void SaveTaskItem()
        {
            if(editingIndex > -1)
            {
                TaskItems.RemoveAt(editingIndex);
                editingIndex = -1;
            }

            TaskItemSetupIsVisible = false;
            OverlayIsVisible = false;
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
            OverlayIsVisible = true;
            TaskItemSetup = new TaskItemSetupViewModel();
        }

        #endregion

        #region Private Methods

        private void InitializeCommands()
        {
            AddTaskCommand = new RelayCommand(AddTask);
            SaveTaskItemCommand = new RelayCommand(SaveTaskItem);
            TrashCommand = new RelayCommand(Trash);
            OpenDaySelectionCommand = new RelayCommand(OpenDaySelection);
            SaveDaySelectionCommand = new RelayCommand(SaveDaySelection);
        }

        #endregion
    }
}
