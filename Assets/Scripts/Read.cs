using UnityEngine;

public class ReadString : MonoBehaviour
{
    private string attempt;
    private CheckCode check;

    public void Start()
    {
        check = GetComponent<CheckCode>();
        var goal = GetComponent<DestinationGoal>().enabled;
        goal = false;
    }

    public void ReadStringInput(string input)
    {
        attempt = input;
        Debug.Log(attempt);
        check.check(attempt);
    }
}
