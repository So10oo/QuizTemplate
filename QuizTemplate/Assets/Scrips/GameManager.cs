using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BaseLevel[] Levels;

    [SerializeField] private LevelDisplay _levelDisplay;

    [SerializeField] private UnityEvent OnLevelChanged;//совершил переход на другой уровень уровень
    [SerializeField] private UnityEvent StartGame;
    [SerializeField] private UnityEvent OnReadyNextLevel;//стал готов к переходу на следующий уровень 
    [SerializeField] private UnityEvent EndGame;


    private Level _currentLevel;
    public Level CurrentLevel
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
                _levelDisplay.QuestionAndOptionsDisplay(_currentLevel);
                OnLevelChanged.Invoke();
            }
        }
    }

    void Start()
    {
        SetLevels();
        SetLevel(0);
        StartGame.Invoke();
    }

    public void NextLevel()
    {
        int indexNextLevel = Array.IndexOf(Levels, (BaseLevel)CurrentLevel) + 1;
        SetLevel(indexNextLevel);
        if (indexNextLevel == Levels.Length)
            EndGame.Invoke();
    }

    private void SetLevels()
    {
        for (int indexLevel = 0; indexLevel < Levels.Length; indexLevel++)
        {
            switch (Levels[indexLevel])
            {
                case Level level:
                    Levels[indexLevel] = level;
                    break;
                case TwoVariableLevel twoVariableLevel:
                    Levels[indexLevel] = (Level)twoVariableLevel;
                    break;
                default:
                    Debug.Log("ќшибка!");
                    break;
            }
        }
    }

    private void SetLevel(int indexLevel)
    {
        if (indexLevel >= 0 && indexLevel < Levels.Length)
        {
            CurrentLevel = (Level)Levels[indexLevel];          
        }

    }
}
