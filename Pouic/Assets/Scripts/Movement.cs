using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1f;
    public float rotateSpeed = 1f;

    Rigidbody rb;

    [HideInInspector]
    public Vector3 direction = new Vector3();
    [HideInInspector]
    public float rotateDirection = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(direction * speed, ForceMode.VelocityChange);

        rb.AddTorque(new Vector3(0, rotateDirection * rotateSpeed, 0), ForceMode.Acceleration);
    }

    /*
    private void FixedUpdate()
    {
        // for replace Rigidbody Drag

        //rb.AddForce(-rb.velocity * acceleration * 2);
    }
    */
}
