using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class ChangeCharacter : MonoBehaviour
{
    [Header("player then spirit")]
    public List<GameObject> controllables;
    int active = 0;

    [Header("What key should the player press to use this interactable?")]
    public KeyCode keycode;

    private bool triggerEntered;
    private GameObject player;
    private GameObject spirit;
    private CinemachineCamera camera;

    private bool start;

    public void ChooseCharacter(int choice)
    {
        camera = GameObject.FindAnyObjectByType<CinemachineCamera>();
        active = choice;

        spirit.GetComponent<TrailRenderer>().Clear();

        if (start == false)
        {
            player.transform.position = new Vector2(spirit.transform.position.x, spirit.transform.position.y);
            spirit.transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
        }

        if (choice == 0)
        {
            spirit.SetActive(false);
            camera.Lens.Equals(2);
            spirit.GetComponent<PlayerInputController>().enabled = false;
            player.GetComponent<PlayerInputController>().enabled = true;
            player.GetComponent<PlayerAttackManager>().enabled = true;
        }
        if (choice == 1)
        {
            spirit.SetActive(true);
            camera.Lens.Equals(3);
            spirit.GetComponent<PlayerInputController>().enabled = true;
            player.GetComponent<PlayerInputController>().enabled = false;
            player.GetComponent<PlayerAttackManager>().enabled = false;
        }
    }

    private void Start()
    {
        start = true;
        player = controllables[0];
        spirit = controllables[1];
        ChooseCharacter(0);
        start = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(keycode) && triggerEntered == true)
        {
            var v = player.GetComponent<activePlayer>().value;
            if (v == 0)
            {
                ChooseCharacter(1);
            }
            else
            {
                ChooseCharacter(0);
            }
            player.SendMessage(nameof(activePlayer.updateValue));
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        camera = GameObject.FindAnyObjectByType<CinemachineCamera>();
        camera.Lens.Equals(2);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        triggerEntered = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) triggerEntered = false;
    }
}
