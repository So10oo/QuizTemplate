using UnityEngine;

public abstract class BaseLevel : ScriptableObject , ILevel
{
    public string Question;

    public abstract Level GetLevel();
}

