namespace DailyPlanner
{
    public class TimeSelectionDesignModel : TimeSelectionViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static TimeSelectionDesignModel Instance = new TimeSelectionDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TimeSelectionDesignModel()
        {
            HeaderLabel = "DesignModel";
        } 

        #endregion
    }
}
