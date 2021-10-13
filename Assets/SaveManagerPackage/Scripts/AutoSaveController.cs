using System;
using UnityEngine;

namespace SaveManagerPackage.Scripts
{
    public class AutoSaveController : MonoBehaviour
    {
        private const float MinTimeBetweenSaves = 10f;

        private static float _currentTimeBetweenSaves = MinTimeBetweenSaves;
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            _currentTimeBetweenSaves += Time.deltaTime;
        }

        private void TryAutoSave()
        {
            if (!CanAutoSave())
            {
                return;
            }
            
            SaveManager.SaveAll();
            _currentTimeBetweenSaves = 0;
        }

        private bool CanAutoSave()
        {
            return _currentTimeBetweenSaves >= MinTimeBetweenSaves;
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus)
            {
                TryAutoSave();
            }
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                TryAutoSave();
            }
        }

        public void OnApplicationQuit()
        {
            TryAutoSave();
        }
    }
}