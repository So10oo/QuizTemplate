using UnityEngine;

[CreateAssetMenu(fileName = "Level 1", menuName = "New TwoVariableLevel", order = 2)]
public class TwoVariableLevel : BaseLevel
{
    public BaseOption[] Options = new BaseOption[4];
#if UNITY_EDITOR
    [TextArea(1, 10)]
#endif
    public string TruthfulMessage = "Правильный ответ!";
#if UNITY_EDITOR
    [TextArea(1, 10)]
#endif
    public string DeceitfulMessage = "Правильный ответ:";


    public override Level GetLevel()
    {
        var level = CreateInstance<Level>();
        level.Options = new Option[Options.Length];
        level.Question = Question;
        
        for (int i = 0; i < Options.Length; i++)
        {
            var option = new Option()
            {
                Truthful = Options[i].Truthful,
                Value = Options[i].Value
            };
            option.Message = Options[i].Truthful ?
                TruthfulMessage : DeceitfulMessage;
            level.Options[i] = option;
        };
        return level;
    }
}
