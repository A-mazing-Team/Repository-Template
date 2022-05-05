using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmazingTeam.Saves
{
    public static class Saves
    {
        #region Variables
        public static int Level;
        public static int Location;
        public static int Coins;
        public static bool Sounds;
        public static bool Vibro;
        #endregion

        #region Constructor
        static Saves()
        {
            Level = PlayerPrefs.GetInt("Level", 0);
            Location = PlayerPrefs.GetInt("Location", 0);
            Coins = PlayerPrefs.GetInt("Coins", 0);
            Sounds = PlayerPrefs.GetInt("Sounds", 1) == 1;
            Vibro = PlayerPrefs.GetInt("Vibro", 1) == 1;

            GameStatusHelper.Create();
        }

        public static void Save()
        {
            PlayerPrefs.SetInt("Level", Level);
            PlayerPrefs.SetInt("Location", Location);
            PlayerPrefs.SetInt("Coins", Coins);
            PlayerPrefs.SetInt("Sounds", Sounds ? 1 : 0);
            PlayerPrefs.SetInt("Vibro", Vibro ? 1 : 0);
        }
        #endregion
    }

    public class GameStatusHelper : MonoBehaviour
    {
        #region Variables
        public static bool Created { get; private set; }

        private const string OBJECT_NAME = "[A-mazing/Saves.Helper]";
        #endregion

        #region Constructor
        public static void Create()
        {
            if (Created)
                return;

            GameObject tempHelper = new GameObject(OBJECT_NAME, typeof(GameStatusHelper));

            DontDestroyOnLoad(tempHelper);

            Created = true;
        }
        #endregion

        #region UnityMethods
        private void OnApplicationQuit()
        {
            Saves.Save();
        }

        private void OnApplicationPause(bool pause)
        {
            if (pause)
                OnApplicationQuit();
        }

        private void OnApplicationFocus(bool focus)
        {
            if (!focus)
                OnApplicationQuit();
        }

        private void OnDestroy()
        {
            OnApplicationQuit();
        }
        #endregion
    }
}
