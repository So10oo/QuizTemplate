using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    static LevelContainer Container;

    [SerializeField] private LevelDisplay _levelDisplay;

    [SerializeField] private UnityEvent OnLevelChanged;//совершил переход на другой уровень уровень
    [SerializeField] private UnityEvent StartGame;
    [SerializeField] private UnityEvent EndGame;


    private ILevel _currentLevel;
    ILevel CurrentLevel
    {
        get
        {
            return _currentLevel;
        }
        set
        {
            if (value != _currentLevel)
            {
                _currentLevel = value;
                _levelDisplay.QuestionAndOptionsDisplay(_currentLevel.GetLevel());
                OnLevelChanged.Invoke();
            }
        }
    }

    private ILevel[] Levels;
    void Start()
    {
        Levels = Container.GetLevels();
        StartCoroutine(Levels.CoroutineShuffle(() =>
        {
            SetLevel(0);
            StartGame.Invoke();
        }));
    }

    public void NextLevel()
    {
        int indexNextLevel = Array.IndexOf(Levels, CurrentLevel) + 1;
        if (indexNextLevel == Levels.Length)
            EndGame.Invoke();
        else
            SetLevel(indexNextLevel);
    }

    private void SetLevel(int indexLevel)
    {
        if (indexLevel >= 0 && indexLevel < Levels.Length)
            CurrentLevel = Levels[indexLevel];
    }

    public static void SetKompleksitas(LevelContainer container)
    {
        Container = container;
    }

    [ContextMenu("Save")]
    public void Save()
    {
        Level[] ls = new Level[Levels.Length];
        for (int i = 0; i < Levels.Length; i++)
            ls[i] = Levels[i].GetLevel();

        var jsonLevels = JsonConvert.SerializeObject(ls, Formatting.Indented);
        //var jsonLevels = JsonUtility.ToJson(ls, true);
        //var path = Path.Combine(Application.persistentDataPath + "/Save.json");

        File.WriteAllText("Save.json", jsonLevels);

        var a = JsonConvert.DeserializeObject<Level[]>(jsonLevels);
    }
}
