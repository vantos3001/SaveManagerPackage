using System.Collections.Generic;
using SaveManagerPackage.Scripts.Guid;
using UnityEngine;

namespace SaveManagerPackage.Scripts.Editor.CheckGuid
{
    [CreateAssetMenu(fileName = "CheckGuidAsset", menuName = "Game/Editor/CheckGuidAsset")]
    public class CheckGuidAsset : ScriptableObject
    {
        public List<CheckGuidAssetData> ExcludeList = new List<CheckGuidAssetData>();

        public bool NeedExclude(GuidAsset asset)
        {
            var data = ExcludeList.Find(d => d.Guid == asset.Id && d.Name == asset.name);

            return data != null;
        }
    
        public bool NeedExclude(Guid.Guid guid)
        {
            var data = ExcludeList.Find(d => d.Guid == guid.Id && d.Name == guid.name);

            return data != null;
        }
    }
}
