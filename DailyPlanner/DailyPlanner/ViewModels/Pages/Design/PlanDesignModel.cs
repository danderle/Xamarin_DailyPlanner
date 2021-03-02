using System;
using System.Collections.ObjectModel;

namespace DailyPlanner
{
    /// <summary>
    /// The desig time model to aid in design mode
    /// </summary>
    public class PlanDesignModel : PlanViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static PlanDesignModel Instance = new PlanDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PlanDesignModel()
        {
            OverlayIsVisible = false;
            TaskItemSetupIsVisible = false;
            TotalPlannedTime = new TimeSpan(10, 15, 0);
            TaskItems = new ObservableCollection<TaskItemViewModel>
            {
                new TaskItemViewModel
                {
                    TaskToComplete = "First",
                    StartTime = new TimeSpan(7,1,0),
                    TimeToComplete = new TimeSpan(0,10,0),
                    TrashEditVisible = false,
                },
                new TaskItemViewModel
                {
                    TaskToComplete = "second",
                    StartTime = new TimeSpan(7,8,0),
                    TimeToComplete = new TimeSpan(0,10,0),
                    TrashEditVisible = true,
                },
                new TaskItemViewModel
                {
                    TaskToComplete = "third",
                    StartTime = new TimeSpan(8,30,0),
                    TimeToComplete = new TimeSpan(0,10,0),
                },
                new TaskItemViewModel
                {
                    TaskToComplete = "fifth",
                    StartTime = new TimeSpan(9,1,0),
                    TimeToComplete = new TimeSpan(0,10,0),
                },
                new TaskItemViewModel
                {
                    TaskToComplete = "sixth",
                    StartTime = new TimeSpan(10,1,0),
                    TimeToComplete = new TimeSpan(0,10,0),
                },
            };
        } 

        #endregion
    }
}
