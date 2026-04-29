using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
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

    private bool start;

    public void ChooseCharacter(int choice)
    {
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
            spirit.GetComponent<PlayerInputController>().enabled = false;
            player.GetComponent<PlayerInputController>().enabled = true;
        }
        if (choice == 1)
        {
            spirit.SetActive(true);
            spirit.GetComponent<PlayerInputController>().enabled = true;
            player.GetComponent<PlayerInputController>().enabled = false;
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
            player.SendMessage("updateValue");
        }
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
