using Unity.Cinemachine;
using UnityEngine;

public class dontDestroyOnLoad : MonoBehaviour
{
    private static dontDestroyOnLoad instance;

    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static dontDestroyOnLoad GetInstance()
    {
        return instance;
    }
}
