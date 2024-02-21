using UnityEngine;

namespace Assets.Scrips
{
    public class SingletonClass<T> : MonoBehaviour where T : SingletonClass<T>
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
