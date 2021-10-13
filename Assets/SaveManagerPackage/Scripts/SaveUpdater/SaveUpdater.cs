using UnityEngine;

namespace SaveManagerPackage.Scripts.SaveUpdater
{
    public static class SaveUpdater
    {
        public static int CurrentSaveVersion = 0;

        public static void TryUpdateSave()
        {
            if (!IsNeedSaveUpdate())
            {
                return;
            }
        
            TryUpdateFrom0To1();

            if (!IsNeedSaveUpdate())
            {
                return;
            }

            Debug.LogError("Need realize Updater to new version");
        }

        private static bool IsNeedSaveUpdate()
        {
            return GameStateManager.GameState.GeneralState.CurrentSaveVersion != CurrentSaveVersion;
        }

        private static void TryUpdateFrom0To1()
        {
            if (1 <= GameStateManager.GameState.GeneralState.CurrentSaveVersion)
            {
                return;
            }
            
            //Do some update. ForExample:
            // GameStateManager.GameState.PlayerState.HasScythe = true;
            
            GameStateManager.GameState.GeneralState.CurrentSaveVersion = 1;
        }
    }
}