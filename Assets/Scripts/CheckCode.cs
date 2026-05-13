using Mono.Cecil.Cil;
using UnityEngine;

public class CheckCode : MonoBehaviour
{
    private string code = "exit";
    [Header("Enter Gate Object")]
    public GameObject gate;
    [Header("Enter Goal Object")]
    public GameObject goal;
    public bool oppositeState;
    public bool active;

    public void check(string a)
    {
        if (a.CompareTo(code) == 0)
        {
            //target.SetActive(oppositeState ? !active : active);
            gate.GetComponent<Interactable>().ChangeSprite();
            goal.SetActive(true);
        }
    }
}
