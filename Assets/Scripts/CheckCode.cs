using Mono.Cecil.Cil;
using UnityEngine;

public class CheckCode : MonoBehaviour
{
    private string code = "hdk";
    [Header("Enter Gate Object")]
    public GameObject target;
    public bool oppositeState;
    public bool active;

    public void Start()
    {
        var goal = target.GetComponent<DestinationGoal>().enabled;
        goal = false;
    }

    public void check(string a)
    {
        if (a.CompareTo(code) == 0)
        {
            //target.SetActive(oppositeState ? !active : active);
            target.GetComponent<Interactable>().ChangeSprite();
        }
    }
}
