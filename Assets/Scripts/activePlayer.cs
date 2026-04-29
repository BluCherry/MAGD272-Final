using UnityEngine;

public class activePlayer : MonoBehaviour
{
    public int value;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        value = 0;
    }

    void updateValue()
    {
        if (value == 0)
        {
            value = 1;
        }
        else if (value == 1)
        {
            value = 0;
        }
    }
}
