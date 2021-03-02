using System;

namespace DailyPlanner
{
    /// <summary>
    /// The desig time model to aid in design mode
    /// </summary>
    public class TaskItemDesignModel : TaskItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static TaskItemDesignModel Instance = new TaskItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TaskItemDesignModel()
        {
            TaskToComplete = "First";
            StartTime = new TimeSpan(7, 1, 0);
            TimeToComplete = new TimeSpan(0, 10, 0);
            TrashEditVisible = true;
        } 

        #endregion
    }
}
