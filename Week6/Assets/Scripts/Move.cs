using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float movementSpeed;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()

    {
        //float direction = Input.GetAxisRaw("Horizontal");
        //float moveDirection = Input.GetAxisRaw("Vertical");

        //transform.Translate(Vector3.forward * moveDirection * Time.deltaTime * movementSpeed);

        //transform.Rotate(0, rotationSpeed*Time.deltaTime*direction, 0);
        
    }
    private void FixedUpdate()
    {
        float wMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");
        Vector3 moveInput = new Vector3 (wMovement,0 ,zMovement);
        rb.MovePosition(transform.position + moveInput * Time.deltaTime * movementSpeed);
    }
}
