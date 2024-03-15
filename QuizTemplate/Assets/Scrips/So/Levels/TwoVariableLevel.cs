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


    public override Level GetLevel()
    {
        var level = new Level()
        {
            Options = new Option[Options.Length],
            Question = Question,
        };
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
