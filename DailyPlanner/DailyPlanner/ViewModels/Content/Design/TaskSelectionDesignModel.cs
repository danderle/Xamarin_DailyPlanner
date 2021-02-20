using System.Collections.Generic;

namespace DailyPlanner
{
    public class TaskSelectionDesignModel : TaskSelectionViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static TaskSelectionDesignModel Instance = new TaskSelectionDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TaskSelectionDesignModel()
        {
            
        } 

        #endregion
    }
}
