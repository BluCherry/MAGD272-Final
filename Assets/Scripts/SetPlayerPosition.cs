using UnityEngine;
using UnityEngine.SceneManagement;

public class SetPlayerPosition : MonoBehaviour
{
    private GameObject player;

    void Awake()
    {
        var active = SceneManager.GetActiveScene().buildIndex;
        player = GameObject.Find("Player");

        if (active == 3)
        {
            player.transform.position = new Vector3(-6.15f, -1.87f, 0f);
        }
        if (active == 2)
        {
            player.transform.position = new Vector3(-7.9f, -4.34f, 0f);
        }
    }
}
