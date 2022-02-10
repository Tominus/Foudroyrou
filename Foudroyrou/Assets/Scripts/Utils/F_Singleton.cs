using UnityEngine;

public class F_Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T instance = null;

    public static T Instance => instance;

    protected virtual void Awake()
    {
        if (instance)
        {
            Debug.Log("UwU");
            Destroy(gameObject);
            return;
        }
        instance = this as T;
    }
}