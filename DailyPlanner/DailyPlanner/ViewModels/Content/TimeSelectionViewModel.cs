using System;
using System.Collections.Generic;
using System.Linq;

namespace DailyPlanner
{
    /// <summary>
    /// View model for the <see cref="TimeSelectionContent"/>
    /// </summary>
    public class TimeSelectionViewModel : BaseViewModel
    {
        #region Public Properties

        public bool IsVisible { get; set; } = false;

        public int CurrentHour { get; set; } = 0;

        public int CurrentMinute { get; set; } = 0;

        public string HeaderLabel { get; set; } = "";

        public List<int> Hours { get; set; } = new List<int>();

        public List<int> Minutes { get; set; } = new List<int>();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TimeSelectionViewModel()
        {
            InitializeProperties();
        }

        /// <summary>
        /// Overloaded constructor
        /// </summary>
        public TimeSelectionViewModel(string headerLabel)
        {
            InitializeProperties();
            HeaderLabel = headerLabel;
        }

        #endregion

        #region Public Methods

        public TimeSpan GetTime()
        {

            return new TimeSpan(CurrentHour, CurrentMinute, 0);
        }

        public DateTime GetStartTime()
        {

            return new DateTime();
        }

        public TimeSpan GetTimeToComplete()
        {
            return new TimeSpan(CurrentHour, CurrentMinute, 0);
        }

        #endregion

        #region Private Methods

        private void InitializeProperties()
        {
            Hours = Enumerable.Range(0, 24).ToList();
            Minutes = Enumerable.Range(0, 60).ToList();
        } 

        #endregion
    }
}
