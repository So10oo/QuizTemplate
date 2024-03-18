using Newtonsoft.Json;
using System.IO;
using UnityEditor;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    [SerializeField] LevelContainer _container;
    [SerializeField] string _pathSave;
    [SerializeField] string _pathLoad;

    [ContextMenu("Save")]
    public void Save()
    {
        var Levels = _container.GetLevels();
        Level[] ls = new Level[Levels.Length];
        for (int i = 0; i < Levels.Length; i++)
            ls[i] = Levels[i].GetLevel();

        var jsonLevels = JsonConvert.SerializeObject(ls, Formatting.Indented);

        File.WriteAllText(_pathSave + "Save.json", jsonLevels);
    }


    [ContextMenu("Load")]
    public void Load()
    {
        var jsonLevels = File.ReadAllText(_pathSave + "Save.json");

        var Levels = JsonConvert.DeserializeObject<Level[]>(jsonLevels);
       

        foreach (Level lvl in Levels)
        {
            string name = string.Join("_", lvl.Question.Split(Path.GetInvalidFileNameChars()));
            //string name = Regex.Replace(lvl.Question, @"(?<=^\s*)\s|\s(?=\s*$)", "_");//lvl.Question.Replace(" ", "_");
            AssetDatabase.CreateAsset(lvl, _pathLoad + name + ".asset");
        }
         
        AssetDatabase.SaveAssets();
        
    }
}
