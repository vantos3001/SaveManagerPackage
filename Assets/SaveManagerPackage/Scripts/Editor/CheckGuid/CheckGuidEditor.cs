using System;
using System.Collections.Generic;
using SaveManagerPackage.Scripts.Guid;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace SaveManagerPackage.Scripts.Editor.CheckGuid
{
    public class CheckGuidEditor : MonoBehaviour
    {
        private class EditorGuidData
        {
            public string Id;
            public string Name;
            public string From;

            public EditorGuidData(string id, string name, string from)
            {
                Id = id;
                Name = name;
                From = from;
            }

            public override string ToString()
            {
                return $"Name = {Name}; From {From}";
            }
        }

        [MenuItem("Tools/Game/ValidateGuid")]
        private static void ValidateGuid()
        {
            var checkGuidAssetPath = "Assets/Editor/CheckGuid/CheckGuidAsset.asset";
            var checkGuidAsset = AssetDatabase.LoadAssetAtPath<CheckGuidAsset>(checkGuidAssetPath);

            if (checkGuidAsset == null)
            {
                Debug.LogError($"{nameof(checkGuidAsset)} is null by path = {checkGuidAssetPath}");
                return;
            }
        
            var guidAssets = FindGuidAssetsByType(checkGuidAsset);
            var guidObjects = FindGuidObjectsOnScenes(checkGuidAsset);

            var generalGuids = new List<EditorGuidData>();
            generalGuids.AddRange(guidAssets);
            generalGuids.AddRange(guidObjects);

            for (var firstElementIndex = 0; firstElementIndex < generalGuids.Count - 1; firstElementIndex++)
            {
                for (int secondElementIndex = firstElementIndex + 1;
                    secondElementIndex < generalGuids.Count;
                    secondElementIndex++)
                {
                    var firstElement = generalGuids[firstElementIndex];
                    var secondElement = generalGuids[secondElementIndex];

                    CheckGuid(firstElement, secondElement);
                }
            }

            Debug.Log("There was checked Guids. GuidAssetsCount = " + guidAssets.Count);
            Debug.Log("GuidObjectsCount = " + guidObjects.Count);
            Debug.Log("generalGuidsCount = " + generalGuids.Count);
        }

        private static void CheckGuid(EditorGuidData first, EditorGuidData second)
        {
            if (first.Id == second.Id)
            {
                Debug.LogError($"Guid Equals = {first.Id}\n First: {first} \n Second:s {second}");
            }
        }

        private static List<EditorGuidData> FindGuidAssetsByType(CheckGuidAsset checkGuidAsset)
        {
            var datas = new List<EditorGuidData>();
            var guids = AssetDatabase.FindAssets(string.Format("t:{0}", typeof(GuidAsset)));
            foreach (var guid in guids)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var asset = AssetDatabase.LoadAssetAtPath<GuidAsset>(assetPath);
                if (asset == null)
                {
                    continue;
                }

                if (checkGuidAsset.NeedExclude(asset))
                {
                    continue;
                }

                var data = new EditorGuidData(asset.Id, asset.name, nameof(AssetDatabase));
                datas.Add(data);
            }

            return datas;
        }

        private static List<EditorGuidData> FindGuidObjectsOnScenes(CheckGuidAsset checkGuidAsset)
        {
            var scenes = EditorBuildSettings.scenes;

            var list = new List<EditorGuidData>();

            foreach (var scene in scenes)
            {
                try
                {
                    EditorSceneManager.OpenScene(scene.path);
                    var objects = FindObjectsOfType<Guid.Guid>();

                    foreach (var objectGuid in objects)
                    {
                        if (checkGuidAsset.NeedExclude(objectGuid))
                        {
                            continue;
                        }
                    
                        var data = new EditorGuidData(objectGuid.Id, objectGuid.name, scene.path);
                        list.Add(data);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }

            return list;
        }
    }
}