using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class playersMovement : MonoBehaviour
{

    //public
    public float speed;
    public float turnSmoothing = 15f;


    //private
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    //called before physics updates -- physics should go here
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        //update rotation
        Rotating(moveHorizontal, moveVertical);
        
      
    }

    void Rotating (float Horizontal, float Vertical)
    {
        //create a new vector of the horizontal and veritcal inputs
        Vector3 targetDirection = new Vector3(Horizontal, 0f, Vertical);

        //create a rotation based on this new vector assuming that up is the global y axis
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

        //create a rotation that is an increment closer to the target rotation from the players rotation
        Quaternion newRotation = Quaternion.Lerp(rb.rotation, targetRotation, turnSmoothing * Time.deltaTime);

        //change the players rotation to the new rotation
        rb.MoveRotation(newRotation);
    }


}
