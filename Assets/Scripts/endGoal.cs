using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class endGoal : MonoBehaviour
{
    [Header("Uncheck for same states.", order = 4)]
    [Space(10, order = 5)]
    public bool oppositeState;

    [Header("What key should the player press to use this interactable?")]
    public KeyCode keycode;

    [Header("Are the target objects starting in the opposite state (active/inactive)", order = 0)]
    [Space(-10, order = 1)]
    [Header("as this interactiveble? Check for oppposite states, ", order = 2)]
    [Space(-10, order = 3)]

    private bool triggerEntered;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(keycode) && triggerEntered == true)
        {
            interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        triggerEntered = true;
    }

    private void interact()
    {
        SceneController.sceneController.loadScene("Level3");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) triggerEntered = false;
    }

    public bool isInteractable()
    {
        return true;
    }
}
