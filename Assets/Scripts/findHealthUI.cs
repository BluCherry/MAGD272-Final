using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class findHealthUI : MonoBehaviour
{
    private HealthUI ui;

    //private void Start()
    //{
    //    var obj = GameObject.Find("HealthIcons");
    //    ui = obj.GetComponent<HealthUI>();

    //    GetComponent<PlayerHealth>().healthUI = ui;
    //}
    private void OnEnable()
    {
        // Subscribe to the event when this object is enabled
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Always unsubscribe to avoid memory leaks or duplicate calls
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("loading");
        var obj = GameObject.Find("HealthIcons");
        ui = obj.GetComponent<HealthUI>();

        GetComponent<PlayerHealth>().healthUI = ui;
    }
}
