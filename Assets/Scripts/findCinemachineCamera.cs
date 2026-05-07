using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class findCinemachineCamera : MonoBehaviour
{
    private CinemachineCamera camera;
    public GameObject spirit;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
       // camera = GameObject.Find("CinemachineCamera");
        camera = GameObject.FindAnyObjectByType<CinemachineCamera>();
        
        camera.Follow = spirit.transform;
    }
}
