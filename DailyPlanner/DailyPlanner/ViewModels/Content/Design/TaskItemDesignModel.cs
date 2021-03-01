using System.Collections.Generic;

namespace DailyPlanner
{
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
        } 

        #endregion
    }
}
