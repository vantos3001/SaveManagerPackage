using Newtonsoft.Json;
using UnityEngine;

namespace SaveManagerPackage.Scripts
{
    public static class SaveManager 
    {
        public const string GameStateSaveKey = "game_state_save";
        
        private static void SaveToPlayerPrefs<T>(T obj, string key)
        {
            var json = JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
                ,ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            PlayerPrefs.SetString(key, json);
            
            PlayerPrefs.Save();
        
            Debug.Log($"Save {typeof(T)} by path = " + key);
        }
        
        private static void SaveGameState(){
            SaveToPlayerPrefs(GameStateManager.GameState, GameStateSaveKey);
        }

        public static void SaveAll()
        {
            SaveGameState();
        }
    }
}