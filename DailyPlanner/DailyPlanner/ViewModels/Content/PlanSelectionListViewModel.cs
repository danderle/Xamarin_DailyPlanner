using System.Collections.ObjectModel;

namespace DailyPlanner
{
    public class PlanSelectionListViewModel : BaseViewModel
    {
        #region Public Properties

        public ObservableCollection<PlanViewModel> Items { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PlanSelectionListViewModel()
        {
        }

        #endregion

        #region Public Methods


        #endregion
    }
}
