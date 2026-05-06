using UnityEngine;
using UnityEngine.InputSystem;

public class BallScript : MonoBehaviour
{
    private Rigidbody rb;

    public float fuerza = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * fuerza, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * fuerza, ForceMode.Force);
        }
    }
}
