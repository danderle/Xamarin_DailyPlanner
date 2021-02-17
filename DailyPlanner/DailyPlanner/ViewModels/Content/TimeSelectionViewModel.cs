using System.Collections.Generic;
using System.Linq;

namespace DailyPlanner
{
    public class TimeSelectionViewModel : BaseViewModel
    {
        #region Public Properties

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

        private void InitializeProperties()
        {
            Hours = Enumerable.Range(0, 23).ToList();
            Minutes = Enumerable.Range(0, 59).ToList();
        }
    }
}
