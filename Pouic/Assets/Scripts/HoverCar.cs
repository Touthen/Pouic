using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverCar : MonoBehaviour
{
    public Transform[] hoverPoints;
    public float hoverHeight = 1f;
    public float hoverForce = 5f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        foreach (Transform hoverPoint in hoverPoints)
        {
            if (Physics.Raycast(hoverPoint.position, Vector3.down, out RaycastHit hit, hoverHeight))
            {
                rb.AddForceAtPosition(Vector3.up * hoverForce * (1.0f - (hit.distance / hoverHeight)), hoverPoint.transform.position);
            }
        }
    }
}
