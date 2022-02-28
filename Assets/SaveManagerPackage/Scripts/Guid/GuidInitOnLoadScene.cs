using UnityEngine;

namespace SaveManagerPackage.Scripts.Guid
{
    [ExecuteInEditMode]
    public class GuidInitOnLoadScene : MonoBehaviour
    {
        #if UNITY_EDITOR
        
        private void Awake()
        {
            if (!Application.isEditor)
            {
                return;
            }

            var guids = FindObjectsOfType<Guid>(true);

            for (int i = 0; i < guids.Length; i++)
            {
                guids[i].InitOnStart();
            }
        }
        
        #endif
    }
}