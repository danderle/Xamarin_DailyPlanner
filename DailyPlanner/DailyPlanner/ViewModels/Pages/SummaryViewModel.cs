using System.Windows.Input;

namespace DailyPlanner
{
    /// <summary>
    /// The view model for the <see cref="SummaryPage"/>
    /// </summary>
    public class SummaryViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Shows the <see cref="PlanContent"/>
        /// </summary>
        public bool PlanSetupVisible { get; set; } = false;

        /// <summary>
        /// Hides the add plan button because somehow it is not covered by the PlanContent
        /// </summary>
        public bool AddPlanButtonIsVisible => !PlanSetupVisible;

        /// <summary>
        /// The plan to add to the summary list
        /// </summary>
        public PlanViewModel PlanSetup { get; set; }

        /// <summary>
        /// The entire list of added plans
        /// </summary>
        public PlanSelectionListViewModel PlanSelectionList { get; set; } = new PlanSelectionListViewModel();

        #endregion

        #region Commands

        public ICommand AddNewPlanCommand { get; set; }

        public ICommand CancelPlanCommand { get; set; }

        public ICommand SavePlanCommand { get; set; }

        #endregion

        #region Constructor

        public SummaryViewModel()
        {
            InitializeCommands();
            PlanViewModel.EditItem += OnEditItem;
        }

        #endregion

        #region Command Methods

        private void AddNewPlan()
        {
            PlanSetupVisible = true;
            PlanSetup = new PlanViewModel();
        }

        private void CancelPlanSetup()
        {
            PlanSetupVisible = false;
        }

        private void SavePlan()
        {
            PlanSetupVisible = false;
            //dont add the item if we are editing
            if(!PlanSetup.Editing)
            {
                PlanSelectionList.Items.Add(PlanSetup);
            }
            PlanSetup.Editing = false;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Event to edit an existing item in the current list
        /// </summary>
        private void OnEditItem()
        {
            //find the item to edit
            foreach(var item in PlanSelectionList.Items)
            {
                if(item.Editing)
                {
                    PlanSetup = item;
                    break;
                }
            }
            PlanSetupVisible = true;
        }

        #endregion

        #region Private Methods

        private void InitializeCommands()
        {
            AddNewPlanCommand = new RelayCommand(AddNewPlan);
            CancelPlanCommand = new RelayCommand(CancelPlanSetup);
            SavePlanCommand = new RelayCommand(SavePlan);
        }

        #endregion
    }
}
