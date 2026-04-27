using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeInput : MonoBehaviour, IInteractable
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


    [Header("Are the target objects starting in the opposite state (active/inactive)", order = 0)]
    [Space(-10, order = 1)]
    [Header("as this interactiveble? Check for oppposite states, ", order = 2)]
    [Space(-10, order = 3)]


    [Header("How many objects would you like this interactable to turn on? Drag in the objects")]
    public GameObject[] target;

    private bool triggerEntered;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        foreach (var t in target)
        {
            t.SetActive(oppositeState ? !active : active);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keycode) && triggerEntered == true)
        {
            interact();
        }
    }

    public bool isInteractable()
    {
        return true;
    }

    public void interact()
    {
        active = !active;
        
        foreach (var t in target)
        {
            t.SetActive(oppositeState ? !active : active);
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