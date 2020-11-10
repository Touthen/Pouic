using UnityEngine;

public class Player : MonoBehaviour
{
    public new Camera camera;
    public Transform headTransform;

    Movement movement;

    public float headRotationSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move
        float forward = Input.GetAxisRaw("Vertical");
        float torque = Input.GetAxisRaw("Horizontal");

        movement.direction = transform.forward * forward;
        movement.rotateDirection = torque;

        // Head Rotate
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 lookDirection = (hit.point - transform.position).normalized;
            float angleY = -Mathf.Atan2(lookDirection.z, lookDirection.x) * Mathf.Rad2Deg;
            Quaternion angle = Quaternion.Euler(new Vector3(0f, angleY, 0f));

            // TODO use localRotation
            headTransform.rotation = Quaternion.Lerp(headTransform.rotation, angle, headRotationSpeed * Time.deltaTime); // or we can use Quaternion.RotateTowards
        }

        // Camera Zoom
        camera.transform.Translate(new Vector3(0, 0, Input.mouseScrollDelta.y), Space.Self);
    }

    Vector3 GetLookDirection()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
            return (hit.point - transform.position).normalized;

        return Vector3.zero;
    }
}
