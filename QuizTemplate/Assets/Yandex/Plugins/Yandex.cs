using System.Runtime.InteropServices;
using UnityEngine;

[CreateAssetMenu(fileName = "Yandex", menuName = "Yandex", order = 3)]
public class Yandex : ScriptableObject
{
    [DllImport("__Internal")]
    private static extern void ShowAdv();


    public void ShowAdvertisement()
    {
#if UNITY_WEBGL
#if !UNITY_EDITOR
        ShowAdv();
#endif
#endif
    }


}
