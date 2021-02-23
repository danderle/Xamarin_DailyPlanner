using System;
using System.Collections.ObjectModel;

namespace DailyPlanner
{
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
            TaskItems = new ObservableCollection<TaskItem>
            {
                new TaskItem
                {
                    TaskToComplete = "First",
                    StartTime = new TimeSpan(7,1,0),
                    TimeToComplete = new TimeSpan(0,10,0),
                },
                new TaskItem
                {
                    TaskToComplete = "second",
                    StartTime = new TimeSpan(7,8,0),
                    TimeToComplete = new TimeSpan(0,10,0),
                },
                new TaskItem
                {
                    TaskToComplete = "third",
                    StartTime = new TimeSpan(8,30,0),
                    TimeToComplete = new TimeSpan(0,10,0),
                },
                new TaskItem
                {
                    TaskToComplete = "fifth",
                    StartTime = new TimeSpan(9,1,0),
                    TimeToComplete = new TimeSpan(0,10,0),
                },
                new TaskItem
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
