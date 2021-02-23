using System;

namespace DailyPlanner
{

    public class TaskItem
    {
        #region Public Properties

        public string TaskToComplete { get; set; }
        
        public TimeSpan StartTime { get; set; }

        public TimeSpan TimeToComplete { get; set; }

        #endregion

        #region Constructor

        public TaskItem()
        {
        } 

        #endregion
    }
}
