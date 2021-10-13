using Newtonsoft.Json;
using SaveManagerPackage.Scripts.SaveStates;
using UnityEngine;

namespace SaveManagerPackage.Scripts
{
    public static class GameStateManager
    {
        private static GameState _gameState;

        public static GameState GameState
        {
            get
            {
                if (_gameState != null)
                {
                    return _gameState;
                }
            
                _gameState = LoadGameState(out var isFirstPlayerEnterToGame);

                if (isFirstPlayerEnterToGame)
                {
                    InitFirstPlayerEnterToGame();
                }
                
                InitAutoSaveController();

                return _gameState;
            }
        }
        
        private static void InitFirstPlayerEnterToGame()
        {
        }
        
        private static GameState LoadGameState(out bool isFirstPlayerEnterToGame)
        {
            isFirstPlayerEnterToGame = false;
        
            if (!PlayerPrefs.HasKey(SaveManager.GameStateSaveKey))
            {
                isFirstPlayerEnterToGame = true;
                return new GameState();
            }
        
            var json = PlayerPrefs.GetString(SaveManager.GameStateSaveKey);
            
            return JsonConvert.DeserializeObject<GameState>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
                ,ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        private static void InitAutoSaveController()
        {
            var autoSaveGO = new GameObject("AutoSaveController");
            autoSaveGO.AddComponent<AutoSaveController>();
        }
        
        public static void ForceGameState(GameState gameState)
        {
            _gameState = gameState;
            SaveManager.SaveAll();
        }
    }
}
