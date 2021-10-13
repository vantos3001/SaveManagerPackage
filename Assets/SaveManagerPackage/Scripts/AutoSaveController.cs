using UnityEngine;

namespace SaveManagerPackage.Scripts
{
    public class AutoSaveController : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (!hasFocus)
            {
                SaveManager.SaveAll();
            }
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                SaveManager.SaveAll();
            }
        }

        public void OnApplicationQuit()
        {
            SaveManager.SaveAll();
        }
    }
}