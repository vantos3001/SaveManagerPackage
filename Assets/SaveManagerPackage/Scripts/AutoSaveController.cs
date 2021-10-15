using UnityEngine;
using UnityEngine.SceneManagement;

namespace SaveManagerPackage.Scripts
{
    public class AutoSaveController : MonoBehaviour
    {
        private const float MinTimeBetweenSaves = 10f;

        private static float _currentTimeBetweenSaves = MinTimeBetweenSaves;
        
        private void Awake()
        {
            DontDestroyOnLoad(this);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void Update()
        {
            _currentTimeBetweenSaves += Time.deltaTime;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            TryAutoSave();
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

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}