using System;
#if UNITY_EDITOR
using UnityEngine;
#endif


[Serializable]
public class Option : BaseOption
{
#if UNITY_EDITOR
    [TextArea(1, 10)]
#endif
    public string Message;
}

[Serializable]
public class BaseOption
{
#if UNITY_EDITOR
    [TextArea(1, 10)]
#endif
    public string Value;

    public bool Truthful;
}

