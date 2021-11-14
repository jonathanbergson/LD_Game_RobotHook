using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{
    private Rigidbody rb;
    public float dash = 12;
    public float speed = 12;
    public float jumpHeight = 12;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float dirVertical = Input.GetAxis("Vertical");
        float dirHorizontal = Input.GetAxis("Horizontal");

        if (dirHorizontal != 0)
        {
            transform.Translate(Vector3.forward * dirHorizontal * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Vector3 dir = new Vector3(0, dirVertical, dirHorizontal);
            rb.AddForce(dir * dash, ForceMode.Impulse);
        }
    }
}
