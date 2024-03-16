using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BaseLevel[] Levels;

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

    void Start()
    {
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
}
