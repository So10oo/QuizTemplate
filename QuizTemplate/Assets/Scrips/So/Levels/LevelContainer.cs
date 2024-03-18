using UnityEngine;

[CreateAssetMenu(fileName = "Levels", menuName = "New LevelContainer", order = 1)]
public class LevelContainer : ScriptableObject
{
    public BaseLevel[] Levels;

    public ILevel[] GetLevels()
    {
        return Levels;
    }
}
