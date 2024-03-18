using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    static LevelContainer Container;

    [SerializeField] LevelDisplay _levelDisplay;
    [SerializeField] TextMeshProUGUI _endMes;
    [SerializeField] UnityEvent OnLevelChanged;//�������� ������� �� ������ ������� �������
    [SerializeField] UnityEvent StartGame;
    [SerializeField] UnityEvent EndGame;


    ILevel _currentLevel;
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
                _levelDisplay.Response�heck = (b) => 
                { 
                    if (b) 
                        _number�orrectAnswers++; 
                };
                
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

    int _number�orrectAnswers = 0;
    public void EndMes()
    {
        _endMes.text = $"����� �����!\n<color=#00FF00>���������� �������: {_number�orrectAnswers}\n<color=#FF0000>������������ �������: {Container.GetLevels().Length - _number�orrectAnswers}";
    }


    public static void SetKompleksitas(LevelContainer container)
    {
        Container = container;
    }
 
}
