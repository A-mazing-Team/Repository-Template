using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public static class SaveSystem
{
    private static string _mobileDataPath = $"{Application.persistentDataPath}/";
    private static string _windowsDataPath = $"{Application.dataPath}/Saves/";

    private const string FILES_TYPE = ".json";


    public static void SaveToJson<T>(T saveObject, string fileName)
    {
#if UNITY_IOS && !UNITY_EDITOR
        string path = $"{_mobileDataPath}{fileName}{FILES_TYPE}";
#elif UNITY_ANDROID && !UNITY_EDITOR
        string path = $"{_mobileDataPath}{fileName}{FILES_TYPE}";
#else
        string path = $"{_windowsDataPath}{fileName}{FILES_TYPE}";
#endif

        string json = JsonUtility.ToJson(saveObject);
        File.WriteAllText(path, json);
    }
    public static T TryLoadFromJson<T>(string fileName) where T : new()
    {
#if UNITY_IOS && !UNITY_EDITOR
        string path = $"{_mobileDataPath}{fileName}{FILES_TYPE}";
#elif UNITY_ANDROID && !UNITY_EDITOR
        string path = $"{_mobileDataPath}{fileName}{FILES_TYPE}";
#else
        string path = $"{_windowsDataPath}{fileName}{FILES_TYPE}";
#endif

        if (File.Exists(path) == false) return new T();

        string json = File.ReadAllText(path);
        T loadedObject = JsonUtility.FromJson<T>(json);

        return loadedObject;
    }



    #region Save\Load List
    public static void SaveListToJson<T>(List<T> saveObject, string fileName)
    {
#if UNITY_IOS && !UNITY_EDITOR
        string path = $"{_mobileDataPath}{fileName}{FILES_TYPE}";
#elif UNITY_ANDROID && !UNITY_EDITOR
        string path = $"{_mobileDataPath}{fileName}{FILES_TYPE}";
#else
        string path = $"{_windowsDataPath}{fileName}{FILES_TYPE}";
#endif

        string json = JsonHelper.ToJson(saveObject.ToArray());
        File.WriteAllText(path, json);
    }
    public static List<T> TryLoadListFromJson<T>(string fileName) where T : new()
    {
#if UNITY_IOS && !UNITY_EDITOR
        string path = $"{_mobileDataPath}{fileName}{FILES_TYPE}";
#elif UNITY_ANDROID && !UNITY_EDITOR
        string path = $"{_mobileDataPath}{fileName}{FILES_TYPE}";
#else
        string path = $"{_windowsDataPath}{fileName}{FILES_TYPE}";
#endif

        if (File.Exists(path) == false) return new List<T>();

        string json = File.ReadAllText(path);
        List<T> loadedObject = JsonHelper.FromJson<T>(json).ToList();

        return loadedObject;
    }
    #endregion
}