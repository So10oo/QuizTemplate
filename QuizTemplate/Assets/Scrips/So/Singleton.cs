using UnityEngine;

namespace Assets.Scrips
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        public static T instance;

        private void Awake()
        {
            MakeSingleton();
        }

        private void MakeSingleton()
        {
            if (instance == null)
            {
                instance = (T)this;
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
                Destroy(gameObject);
        }
    }
}
