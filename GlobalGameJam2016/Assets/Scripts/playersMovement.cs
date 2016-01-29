using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class playersMovement : MonoBehaviour
{

    //public
    public float speed;

    //private
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //called before physics updates -- physics should go here
    void fixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }


}
