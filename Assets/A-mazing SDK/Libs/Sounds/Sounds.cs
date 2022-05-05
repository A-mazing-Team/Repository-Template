using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AmazingTeam.Sounds
{
    public class Sounds : Singleton<Sounds>
    {
        #region Variables
        [Header("Sounds Settings")]
        [SerializeField] private AudioClip[] _sounds;

        private AudioSource _mainSource;
        #endregion

        #region UnityMethods 
        override public void Awake()
        {
            _mainSource = GetComponent<AudioSource>();
            base.Awake();
        }
        #endregion

        #region SoundsLogic 
        public void PlaySound(SoundType type, float volume = 1f)
        {
            if (!_mainSource)
                _mainSource = GetComponent<AudioSource>();

            int id = (int)type;

            if (id < _sounds.Length)
                _mainSource.PlayOneShot(_sounds[id], volume);

        }
        #endregion

        #region Enums
        public enum SoundType
        {

        }
        #endregion
    }
}