using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace DailyPlanner
{
    public class SummaryViewModel : BaseViewModel
    {
        #region Field

        #endregion
        #region Public Properties

        public bool PlanSetupVisible { get; set; } = false;

        public PlanViewModel PlanSetup { get; set; }

        public PlanSelectionListViewModel PlanSelectionList { get; set; } = new PlanSelectionListViewModel();

        #endregion

        #region Commands

        public ICommand AddNewPlanCommand { get; set; }

        public ICommand CancelPlanCommand { get; set; }

        public ICommand SavePlanCommand { get; set; }

        #endregion

        #region Constructor

        public SummaryViewModel(INavigationService _navigationService)
        {
            InitializeCommands();
        }

        #endregion

        #region Command Methods

        private void AddNewPlan()
        {
            PlanSetupVisible = true;
            PlanSetup = new PlanViewModel();
        }

        private void CancelPlan()
        {
            PlanSetupVisible = false;
        }

        private void SavePlan()
        {
            PlanSetupVisible = false;
        }

        #endregion

        #region Private Methods

        private void InitializeCommands()
        {
            AddNewPlanCommand = new RelayCommand(AddNewPlan);
            CancelPlanCommand = new RelayCommand(CancelPlan);
            SavePlanCommand = new RelayCommand(SavePlan);
        }

        #endregion
    }
}
