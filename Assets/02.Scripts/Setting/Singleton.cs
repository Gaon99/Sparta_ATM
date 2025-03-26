using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T Instance;

    public static T instance
    {
        get
        {
            if (Instance == null)
            {
                Instance = FindObjectOfType<T>();
                if (Instance == null)
                {

                    Instance = new GameObject(typeof(T).Name).AddComponent<T>();
                }
            }

            return Instance;
        }
        set { Instance = value; }
    }

    protected virtual void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }
}