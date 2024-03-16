using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Level 1", menuName = "New Level", order = 1)]
[Serializable]
public class Level : BaseLevel
{
    public Option[] Options;

    public override Level GetLevel()
    {
        return this;
    }

}
