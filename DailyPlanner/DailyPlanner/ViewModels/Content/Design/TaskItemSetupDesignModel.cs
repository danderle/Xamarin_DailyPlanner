using System.Collections.Generic;

namespace DailyPlanner
{
    public class TaskItemSetupDesignModel : TaskItemSetupViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static TaskItemSetupDesignModel Instance = new TaskItemSetupDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TaskItemSetupDesignModel()
        {
            TimeSetup.Hours = new List<int> { 1, 2, 34 };
            TimeSetup.Minutes = new List<int> { 1, 2, 34 };
        } 

        #endregion
    }
}
