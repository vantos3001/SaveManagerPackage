using System;

namespace SaveManagerPackage.Scripts.SaveStates
{
    [Serializable]
    public class GeneralState : ISaveState
    {
        public int CurrentSaveVersion = SaveUpdater.SaveUpdater.CurrentSaveVersion;
    }
}
