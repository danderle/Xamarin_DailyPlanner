using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace DailyPlanner
{
    public class SummaryViewModel : BaseViewModel
    {
        #region Fields

        private INavigationService navigationService;

        #endregion

        #region Public Properties

        public PlanSelectionListViewModel PlanSelectionList { get; set; } = new PlanSelectionListViewModel();

        #endregion

        #region Commands

        public ICommand AddPlanCommand { get; set; }

        #endregion

        #region Constructor

        public SummaryViewModel(INavigationService _navigationService)
        {
            navigationService = _navigationService;
            InitializeCommands();
        }

        #endregion

        #region Command Methods

        private async void AddPlanAsync()
        {
            // navigate to the Plan page
            await navigationService.NavigateToAsync<PlanViewModel>();
        }

        #endregion

        #region Private Methods

        private void InitializeCommands()
        {
            AddPlanCommand = new RelayCommand(AddPlanAsync);
        }

        #endregion
    }
}
