using UnityEngine;

[CreateAssetMenu(fileName = "data", menuName = "Scene Manager", order = 51)]
public class SceneManager : ScriptableObject
{
    public void LoadScene(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }

    public void GameQuit()
    {
        Application.Quit(); 
    }
}
