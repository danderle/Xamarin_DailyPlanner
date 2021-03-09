using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DailyPlanner
{
    public class DaySelectionListViewModel : BaseViewModel
    {
        #region Class

        public class DaySelectionItemViewModel : BaseViewModel
        {
            public bool IsChecked { get; set; } = false;

            public string Day { get; set; } = string.Empty;

            public DaySelectionItemViewModel()
            {
            }
        }

        #endregion

        #region Public Properties

        public ObservableCollection<DaySelectionItemViewModel> DaySelectionList { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public DaySelectionListViewModel()
        {
            DaySelectionList = new ObservableCollection<DaySelectionItemViewModel>
            {
                new DaySelectionItemViewModel
                {
                    Day = "Monday"
                },
                new DaySelectionItemViewModel
                {
                    Day = "Tuesday"
                },
                new DaySelectionItemViewModel
                {
                    Day = "Wednesday"
                },
                new DaySelectionItemViewModel
                {
                    Day = "Thursday"
                },
                new DaySelectionItemViewModel
                {
                    Day = "Friday"
                },
                new DaySelectionItemViewModel
                {
                    Day = "Saturday"
                },
                new DaySelectionItemViewModel
                {
                    Day = "Sunday"
                },
            };
        }

        #region Public Methods

        public List<string> GetSelected()
        {
            var items = new List<string>();
            foreach(var item in DaySelectionList)
            {
                if(item.IsChecked)
                {
                    items.Add(item.Day.Substring(0, 3));
                }
            }
            return items;
        }

        #endregion

        #endregion
    }
}
