using System;

namespace DailyPlanner
{
    /// <summary>
    /// The desig time model to aid in design mode
    /// </summary>
    public class DaySelectionListDesignModel : DaySelectionListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static DaySelectionListDesignModel Instance = new DaySelectionListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public DaySelectionListDesignModel()
        {
        } 

        #endregion
    }
}
