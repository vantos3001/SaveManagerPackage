using UnityEditor;
using UnityEngine;

public class DeleteSaveEditor : MonoBehaviour
{
    [MenuItem("Tools/Game/DeleteSave")]
    private static void DeleteSave()
    {
        PlayerPrefs.DeleteAll();
    }
}
