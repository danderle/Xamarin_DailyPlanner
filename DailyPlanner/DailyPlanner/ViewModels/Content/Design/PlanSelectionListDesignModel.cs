using System;
using System.Collections.ObjectModel;

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
            Items = new ObservableCollection<PlanViewModel>
            {
                new PlanViewModel
                {
                    TotalTasks = 10,
                    DaysValid = "Mon, Tue, Wed",
                    TotalPlannedTime = new TimeSpan(5,20,0),
                },
                new PlanViewModel
                {
                    TotalTasks = 9,
                    DaysValid = "Thur, Fri, Sat",
                    TotalPlannedTime = new TimeSpan(5,20,0),
                },
                new PlanViewModel
                {
                    TotalTasks = 1,
                    DaysValid = "Sun",
                    TotalPlannedTime = new TimeSpan(4,20,0),
                },
            };
        } 

        #endregion
    }
}
