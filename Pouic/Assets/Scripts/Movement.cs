using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1f;

    Rigidbody rb;

    [HideInInspector]
    public Vector3 direction = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(direction * speed, ForceMode.Acceleration);
    }

    /*
    private void FixedUpdate()
    {
        //rb.AddForce(-rb.velocity * acceleration * 2);
    }
    */
}
