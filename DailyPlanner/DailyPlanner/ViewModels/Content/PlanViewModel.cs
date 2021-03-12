using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace DailyPlanner
{
    /// <summary>
    /// The view model for the <see cref="PlanContent"/>
    /// </summary>
    public class PlanViewModel : BaseViewModel
    {
        #region Fields

        private int editingIndex = -1;

        #endregion

        #region Public Properties

        /// <summary>
        /// Makes the <see cref="TaskItemSetupContent"/> visible
        /// </summary>
        public bool TaskItemSetupIsVisible { get; set; } = false;

        /// <summary>
        /// Hides everything under the <see cref="TaskItemSetupContent"/>
        /// </summary>
        public bool OverlayIsVisible { get; set; } = false;

        /// <summary>
        /// Makes the <see cref="DaySelectionListContent"/> visible
        /// </summary>
        public bool DaySelectionVisible { get; set; } = false;

        /// <summary>
        /// Makes the delete button visible
        /// </summary>
        public bool DeleteIsVisible { get; set; } = false;

        /// <summary>
        /// Flag for when we are in editing mode
        /// </summary>
        public bool Editing { get; set; } = false;

        /// <summary>
        /// Flag for when we want to delete this item
        /// </summary>
        public bool Delete { get; private set; } = false;

        public int TotalTasks { get; set; } = 0;

        /// <summary>
        /// The days for which this plan is valid
        /// </summary>
        public string DaysValid { get; set; } = "Select Days";

        public TimeSpan TotalPlannedTime { get; set; } = new TimeSpan();

        /// <summary>
        /// the view model for the <see cref="DaySelectionListContent"/>
        /// </summary>
        public DaySelectionListViewModel DaySelectionList { get; set; } = new DaySelectionListViewModel();

        /// <summary>
        /// the view model for the <see cref="TaskItemSetupContent"/>
        /// </summary>
        public TaskItemSetupViewModel TaskItemSetup { get; set; } = new TaskItemSetupViewModel();

        /// <summary>
        /// The entire list of tasks for this planner
        /// </summary>
        public ObservableCollection<TaskItemViewModel> TaskItems { get; set; } = new ObservableCollection<TaskItemViewModel>();

        #endregion

        #region Events

        /// <summary>
        /// Event to delete this item
        /// </summary>
        public static event Action DeleteItem;

        /// <summary>
        /// Event to edit this item
        /// </summary>
        public static event Action EditItem;

        #endregion

        #region Commands

        public ICommand AddTaskCommand { get; set; }

        public ICommand SaveTaskSetupCommand { get; set; }

        public ICommand TrashTaskSetupCommand { get; set; }

        public ICommand OpenDaySelectionCommand { get; set; }
        
        public ICommand SaveDaySelectionCommand { get; set; }

        public ICommand ShowDeleteCommand { get; set; }

        public ICommand HideDeleteCommand { get; set; }

        public ICommand EditPlanCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

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
            //find the task with the delete flag set
            var itemToDelete = TaskItems.First(t => t.TrashItem == true);
            TaskItems.Remove(itemToDelete);
        }

        private void OnItemEdit()
        {
            //find the task with the edit flag set and sets item to be the setup item
            var itemToEdit = TaskItems.First(t => t.EditItem == true);
            TaskItemSetup = new TaskItemSetupViewModel(itemToEdit);
            TaskItemSetupIsVisible = true;
            editingIndex = TaskItems.IndexOf(itemToEdit);
        }

        #endregion

        #region Command Methods

        private void ShowDelete()
        {
            DeleteIsVisible = true;
        }

        private void HideDelete()
        {
            DeleteIsVisible = false;
        }

        private void EditPlan()
        {
            Editing = true;
            EditItem?.Invoke();
        }

        private void DeletePlan()
        {
            Delete = true;
            DeleteItem?.Invoke();
        }

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

        private void TrashTaskSetup()
        {
            TaskItemSetupIsVisible = false;
            DaySelectionVisible = false;
            OverlayIsVisible = false;
        }

        private void SaveTaskSetup()
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
            SaveTaskSetupCommand = new RelayCommand(SaveTaskSetup);
            TrashTaskSetupCommand = new RelayCommand(TrashTaskSetup);
            OpenDaySelectionCommand = new RelayCommand(OpenDaySelection);
            SaveDaySelectionCommand = new RelayCommand(SaveDaySelection);
            ShowDeleteCommand = new RelayCommand(ShowDelete);
            HideDeleteCommand = new RelayCommand(HideDelete);
            EditPlanCommand = new RelayCommand(EditPlan);
            DeleteCommand = new RelayCommand(DeletePlan);
        }

        #endregion
    }
}
