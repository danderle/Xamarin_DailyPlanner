using System;
using System.Collections.ObjectModel;

namespace DailyPlanner
{
    /// <summary>
    /// The desig time model to aid in design mode
    /// </summary>
    public class SummaryDesignModel : SummaryViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static SummaryDesignModel Instance = new SummaryDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SummaryDesignModel() : base(null)
        {
            PlanSelectionList = new PlanSelectionListViewModel
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
                },
            };
        } 

        #endregion
    }
}
