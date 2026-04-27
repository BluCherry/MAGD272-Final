using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeInput : MonoBehaviour
{
    [Header("Uncheck for same states.", order = 4)]
    [Space(10, order = 5)]
    public bool oppositeState;
    
    private SpriteRenderer spriteRenderer;

    private bool value;

    [Header("What key should the player press to use this interactable?")]
    public KeyCode keycode;

    [Header("Is the interactable turned on?")]
    public bool active;

    [Header("Does time stop when paused?")]
    public bool timeStop = true;
    bool paused = false;

    [Header("GameObject that turns on when paused (UI)")]
    public GameObject codeScreen;

    private bool triggerEntered;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        codeScreen.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keycode) && triggerEntered == true)
        {
            interact(paused);
        }
    }

    public bool isInteractable()
    {
        return true;
    }

    public void interact(bool p)
    {
        active = !active;

        if (!p)  // pauses
        {
            paused = true;
            if (codeScreen) codeScreen.SetActive(true);
            if (timeStop) Time.timeScale = 0;
        }
        else    // upauses
        {
            paused = false;
            if (codeScreen) codeScreen.SetActive(false);
            if (timeStop) Time.timeScale = 1;
        }
    }

    public bool isActive()
    {
        return active;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        triggerEntered = true;
        player = other.gameObject;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) triggerEntered = false;
    }
}