using UnityEngine;

[CreateAssetMenu(fileName = "Level 1", menuName = "New TwoVariableLevel", order = 2)]
public class TwoVariableLevel : BaseLevel
{
    public BaseOption[] Options;
#if UNITY_EDITOR
    [TextArea(1, 10)]
#endif
    public string TruthfulMessage;
#if UNITY_EDITOR
    [TextArea(1, 10)]
#endif
    public string DeceitfulMessage;

    public static explicit operator Level(TwoVariableLevel twoVariableLevel)
    {
        var level = new Level()
        {
            Options = new Option[twoVariableLevel.Options.Length],
            Question = twoVariableLevel.Question,
        };
        for (int i = 0; i < twoVariableLevel.Options.Length; i++)
        {
            var option = new Option()
            {
                Truthful = twoVariableLevel.Options[i].Truthful,
                Value = twoVariableLevel.Options[i].Value
            };
            option.Message = twoVariableLevel.Options[i].Truthful ? 
                twoVariableLevel.TruthfulMessage : twoVariableLevel.DeceitfulMessage;
            level.Options[i] = option;
        };
        return level;
    }
}
