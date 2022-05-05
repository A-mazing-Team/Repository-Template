using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace AmazingTeam.Analytics
{
    public class Analytics
    {
        #region Variables
        /// <summary>
        /// Param - level
        /// </summary>
        public static UnityAction<int> OnLevelStart;
        /// <summary>
        /// Param - level
        /// </summary>
        public static UnityAction<int> OnLevelComplete;
        /// <summary>
        /// Param - level
        /// </summary>
        public static UnityAction<int> OnLevelFail;
        #endregion
    }
}
