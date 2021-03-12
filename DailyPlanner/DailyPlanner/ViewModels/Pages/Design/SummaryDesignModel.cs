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
            PlanSetupVisible = true;
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
            PlanSetup = new PlanViewModel
            {
                TotalPlannedTime = new TimeSpan(10, 15, 0),
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
                },
            };
        } 

        #endregion
    }
}
