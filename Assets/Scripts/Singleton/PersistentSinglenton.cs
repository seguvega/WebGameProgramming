using UnityEditor.PackageManager;
using UnityEngine;

public abstract class PersistentSinglenton<T> : MonoBehaviour where T : Component
{
    protected static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<T>();
                if(instance == null)
                {
                    GameObject NewObj = new GameObject(typeof(T).Name + "Generated");
                    instance = NewObj.AddComponent<T>();               
                }
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        InitSingleton();
    }

    protected void InitSingleton()
    {
        if(instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
