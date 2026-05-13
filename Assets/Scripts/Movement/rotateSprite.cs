using UnityEngine;

public class spriteRotation : MonoBehaviour
{
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.linearVelocity.magnitude > 01f)
        {
            transform.up = rb.linearVelocity;
        }
    }
}
