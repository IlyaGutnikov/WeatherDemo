using UnityEngine;

/// <summary>
/// Singletone GameObject.
/// </summary>
public class SingletonGameObject<T> : MonoBehaviour where T : MonoBehaviour
{
    protected static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                T[] instances = FindObjectsOfType(typeof(T)) as T[];

                if (instances.Length == 0)
                {
                    Debug.LogError("An instance of " + typeof(T) +
                    " is needed in the scene, but there is none.");
                }
                else if (instances.Length > 1)
                {
                    Debug.LogError("There is more than one instance of " + typeof(T) +
                    " in the scene.");
                }
                else
                {
                    instance = instances[0];
                    Debug.LogWarning("Something called instance of " + typeof(T) +
                    " before it was initialized.");
                }
            }

            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance == null || instance == this)
        {
            instance = this as T;
            Debug.Log("Instance of " + typeof(T) + " created in the scene.");
        }
        else
        {
            Debug.LogError("Second instance of " + typeof(T) + " created in the scene.");
        }
    }
}