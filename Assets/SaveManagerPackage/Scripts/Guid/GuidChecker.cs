using UnityEngine;

namespace SaveManagerPackage.Scripts.Guid
{
    public static class GuidValidator
    {
        public static bool Validate(Guid guid, string name, string additionalInfo = "")
        {
            if (guid == null)
            {
                Debug.LogError($"Not found guid! gameObjectName = {name}. {additionalInfo}");
                return false;
            }

            return true;
        }
        
        public static bool Validate(string guidId, string name, string additionalInfo = "")
        {
            if (string.IsNullOrEmpty(guidId))
            {
                Debug.LogError($"Not found guid! gameObjectName = {name}. {additionalInfo}");
                return false;
            }

            return true;
        }
        
        public static bool Validate(GuidAsset guid, string name, string additionalInfo = "")
        {
            if (guid == null)
            {
                Debug.LogError($"Not found guid! gameObjectName = {name}. {additionalInfo}");
                return false;
            }

            return true;
        }
    }
}
