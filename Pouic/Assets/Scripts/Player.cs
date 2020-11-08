using UnityEngine;

public class Player : MonoBehaviour
{
    public float aze = 1f;

    Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        /* // Global
        Vector3 direction = new Vector3();

        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        direction.Normalize();

        movement.direction = direction;
        */

        // Local
        float forward = Input.GetAxisRaw("Vertical");
        float torque = Input.GetAxisRaw("Horizontal");

        movement.direction = transform.forward * forward;

        GetComponent<Rigidbody>().AddTorque(new Vector3(0, torque * aze, 0), ForceMode.Acceleration);
    }
}
