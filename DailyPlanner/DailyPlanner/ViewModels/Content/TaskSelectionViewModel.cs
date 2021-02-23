using System.Collections.Generic;

namespace DailyPlanner
{
    public class TaskSelectionViewModel : BaseViewModel
    {
        #region Public Properties

        public bool IsVisible { get; set; } = false;

        public bool DefineCustomTask => string.IsNullOrEmpty(SelectedTask) ? false : SelectedTask.Equals("Other");

        public string SelectedTask { get; set; } = string.Empty;

        public string CustomTask { get; set; } = string.Empty;

        public List<string> PreDefinedTasks { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TaskSelectionViewModel()
        {
            PreDefinedTasks = new List<string>
            {
                "Wake up",
                "Shower",
                "Brush Teeth",
                "Eat Breakfast",
                "Work",
                "Workout",
                "Side project",
                "Other",
            };
        }

        #region Public Methods

        public string GetTask()
        {
            var task = DefineCustomTask ? CustomTask : SelectedTask;
            return task;
        }

        #endregion

        #endregion
    }
}
