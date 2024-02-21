using UnityEngine;
using UnityEngine.Events;

public class MainManager : MonoBehaviour
{
    [SerializeField] UnityEvent StartMainMenu;
    private void Start()
    {
        StartMainMenu.Invoke();
    }
}
