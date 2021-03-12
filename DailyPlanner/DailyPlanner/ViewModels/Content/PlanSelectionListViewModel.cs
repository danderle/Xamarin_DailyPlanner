using System.Collections.ObjectModel;

namespace DailyPlanner
{
    /// <summary>
    /// The view model for the <see cref="PlanSelectionListContent"/>
    /// </summary>
    public class PlanSelectionListViewModel : BaseViewModel
    {
        #region Public Properties

        public ObservableCollection<PlanViewModel> Items { get; set; } = new ObservableCollection<PlanViewModel>();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PlanSelectionListViewModel()
        {
            PlanViewModel.DeleteItem += OnDeleteItem;
        }

        #endregion

        #region Event handlers

        private void OnDeleteItem()
        {
            //finds the item which is set to delete and removes it from the list
            foreach(var item in Items)
            {
                if(item.Delete)
                {
                    Items.Remove(item);
                    break;
                }
            }
        }

        #endregion
    }
}
