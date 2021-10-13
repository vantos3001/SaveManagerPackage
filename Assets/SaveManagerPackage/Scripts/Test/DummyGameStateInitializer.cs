using UnityEngine;

namespace SaveManagerPackage.Scripts.Test
{
    public class DummyGameStateInitializer : MonoBehaviour
    {
        private void Awake()
        {
            var init = GameStateManager.GameState;
        }
    }
}
