using Mono.Cecil.Cil;
using UnityEngine;

public class ReadString : MonoBehaviour
{
    private static string attempt;

    public static void ReadStringInput(string input)
    {
        attempt = input;
        Debug.Log(attempt);
        var mc = new CheckCode();
        mc.check(attempt);
    }
}

public class CheckCode
{
    private string code = "hdk";
    [Header("Enter Gate Object")]
    public GameObject target;
    public bool oppositeState;
    public bool active;

    public void check(string a)
    {
        if (code == a)
        {
            target.SetActive(oppositeState ? !active : active);
            SceneController.sceneController?.loadMainMenu();
        }
    }
}
