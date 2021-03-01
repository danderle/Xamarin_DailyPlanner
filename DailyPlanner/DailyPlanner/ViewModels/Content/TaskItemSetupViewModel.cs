using System.Diagnostics;
using System.Windows.Input;

namespace DailyPlanner
{
    /// <summary>
    /// The view model for the <see cref="TaskItemSetupContent"/>
    /// </summary>
    public class TaskItemSetupViewModel : BaseViewModel
    {
        #region Private Fields

        #endregion

        #region Public Properties

        public int CurrentSetupShowing { get; set; } = 1;

        public bool LeftIsVisible=> CurrentSetupShowing != 0;

        public bool RightIsVisible => CurrentSetupShowing != 2;

        public TimeSelectionViewModel TimeSetup { get; set; } = new TimeSelectionViewModel("Start Time");

        public TimeSelectionViewModel DurationSetup { get; set; } = new TimeSelectionViewModel("Duration");

        public TaskSelectionViewModel TaskSetup { get; set; } = new TaskSelectionViewModel();

        #endregion

        #region Command

        public ICommand LeftCommand { get; set; }

        public ICommand RightCommand { get; set; }

        #endregion

        #region Constructor

        public TaskItemSetupViewModel()
        {
            LeftCommand = new RelayCommand(Left);
            RightCommand = new RelayCommand(Right);
            
            CurrentSetupShowing = 0;
            TaskSetup.IsVisible = true;
        }

        #endregion

        #region Public Methods

        public TaskItemViewModel GetTaskItem()
        {
            var taskItem = new TaskItemViewModel
            {
                TaskToComplete = TaskSetup.GetTask(),
                StartTime = TimeSetup.GetTime(),
                TimeToComplete = DurationSetup.GetTime(),
            };
            return taskItem;
        }

        #endregion

        #region Command Methods

        private void Left()
        {
            if (CurrentSetupShowing > 0)
            {
                CurrentSetupShowing--;
                CurrentSetupVisibility();
            }
        }

        private void Right()
        {
            if (CurrentSetupShowing < 2)
            {
                CurrentSetupShowing++;
                CurrentSetupVisibility();
            }
        }

        #endregion

        #region Private Methods

        private void CurrentSetupVisibility()
        {
            TaskSetup.IsVisible = false;
            TimeSetup.IsVisible = false;
            DurationSetup.IsVisible = false;
            switch (CurrentSetupShowing)
            {
                case 0:
                    TaskSetup.IsVisible = true;
                    break;
                case 1:
                    TimeSetup.IsVisible = true;
                    break;
                case 2:
                    DurationSetup.IsVisible = true;
                    break;
                default:
                    Debugger.Break();
                    break;
            }
        }

        #endregion
    }
}
