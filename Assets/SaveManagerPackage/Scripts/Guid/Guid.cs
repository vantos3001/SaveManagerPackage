#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

namespace SaveManagerPackage.Scripts.Guid
{
    [ExecuteInEditMode]
    public class Guid : MonoBehaviour
    {
        [ReadOnly][SerializeField] private string _id;
        public string Id => _id;

#if UNITY_EDITOR
        private bool _wasInitOnStart;
#endif

#if UNITY_EDITOR
        public void InitOnStart()
        {
            if (!Application.isEditor)
            {
                return;
            }

            _wasInitOnStart = true;
        }
#endif
        
        private void OnValidate()
        {
            GenerateGuid();
        }

        public void OverwriteGuid()
        {
            _id = GuidGenerator.GenerateGuid();
        }

        private void GenerateGuid()
        {
            if (string.IsNullOrEmpty(_id))
            {
                _id = GuidGenerator.GenerateGuid();
                return;
            }

#if UNITY_EDITOR
            if (IsNeedGenerateByPasteOrDuplicate())
            {
                _id = GuidGenerator.GenerateGuid();
                _wasInitOnStart = true;
                Debug.Log("GenerateByPasteOrDuplicate");
                EditorUtility.SetDirty(this);
                return;
            }
#endif
        }


#if UNITY_EDITOR
        private bool IsNeedGenerateByPasteOrDuplicate()
        {
            if (_wasInitOnStart)
            {
                return false;
            }
            
            var e = Event.current;

            if (e == null)
            {
                return false;
            }

            if (e.commandName != "Paste" && e.commandName != "Duplicate")
            {
                return false;
            }

            return true;
        }
        
        private void OnGUI()
        {
            GenerateGuid();
        }
#endif
    }
}
