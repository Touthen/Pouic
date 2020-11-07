using UnityEngine;

public class Player : MonoBehaviour
{
    Movement movement;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3();

        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        direction.Normalize();

        movement.direction = direction;
    }
}
