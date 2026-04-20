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

        foreach (GameObject p in controllables) p.GetComponent<PlayerInputController>().enabled = false;
        foreach (GameObject p in controllables) p.SetActive(false);
        player.SetActive(true);
        spirit.GetComponent<TrailRenderer>().Clear();

        if (start == false)
        {
            player.transform.position = new Vector2(spirit.transform.position.x, spirit.transform.position.y);
            spirit.transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
        }

        controllables[choice].SetActive(true);
        controllables[choice].GetComponent<PlayerInputController>().enabled = true;
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
            if (active == 0)
            {
                ChooseCharacter(1);
            }
            else
            {
                ChooseCharacter(0);
            }
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
