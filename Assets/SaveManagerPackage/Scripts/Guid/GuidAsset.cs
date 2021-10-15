using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR

#endif

namespace SaveManagerPackage.Scripts.Guid
{
    [CreateAssetMenu(fileName = "GuidAsset", menuName = "Game/Tools/GuidAsset")]
    public class GuidAsset : ScriptableObject
    {
        [Header("НЕ ДУБЛИРОВАТЬ!!!")]
        [ReadOnly][SerializeField] private string _id;
        public string Id => _id;

#if UNITY_EDITOR
    
        private void OnValidate()
        {
            GenerateGuid();
        }

        private void GenerateGuid()
        {
            if (string.IsNullOrEmpty(_id))
            {
                _id = System.Guid.NewGuid().ToString();
            
                EditorUtility.SetDirty(this);
                AssetDatabase.SaveAssets();
            }
        }
#endif
    }
}
