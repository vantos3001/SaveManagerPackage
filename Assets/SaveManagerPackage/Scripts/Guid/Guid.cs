using UnityEngine;

namespace SaveManagerPackage.Scripts.Guid
{
    public class Guid : MonoBehaviour
    {
        [ReadOnly][SerializeField] private string _id;
        public string Id => _id;

        private void OnValidate()
        {
            GenerateGuid();
        }


        private void GenerateGuid()
        {
            if (string.IsNullOrEmpty(_id))
            {
                _id = System.Guid.NewGuid().ToString();
            }
        }
    }
}
