namespace DailyPlanner
{
    public class TaskItemSetupViewModel : BaseViewModel
    {
        #region Public Properties

        public TimeSelectionViewModel TimeSetup { get; set; } = new TimeSelectionViewModel("Start Time");

        public TimeSelectionViewModel DurationSetup { get; set; } = new TimeSelectionViewModel("Task Duration");

        #endregion

        #region Constructor

        public TaskItemSetupViewModel()
        {

        } 

        #endregion
    }
}
