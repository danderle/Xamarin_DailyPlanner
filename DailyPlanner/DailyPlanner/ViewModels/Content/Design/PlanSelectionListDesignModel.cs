using System;

namespace DailyPlanner
{
    /// <summary>
    /// The desig time model to aid in design mode
    /// </summary>
    public class PlanSelectionListDesignModel : PlanSelectionListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static PlanSelectionListDesignModel Instance = new PlanSelectionListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PlanSelectionListDesignModel()
        {
        } 

        #endregion
    }
}
