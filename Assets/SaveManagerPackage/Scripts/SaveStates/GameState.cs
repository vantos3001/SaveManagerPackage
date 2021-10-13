using System;

namespace SaveManagerPackage.Scripts.SaveStates
{
    [Serializable]
    public class GameState : ISaveState
    {
        public GeneralState GeneralState = new GeneralState();
    }
}
