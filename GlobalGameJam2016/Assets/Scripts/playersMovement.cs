using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class playersMovement : MonoBehaviour
{

    //public
    public float speed =10f;
    public float turnSmoothing = 15f;

    //private
    private bool carrying = false;
    private resouceManager.resourceType type;
    private bool atPit = false;
    private Rigidbody rb;
    private pitManger pit;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        pit = GameObject.FindGameObjectWithTag("pit").GetComponent<pitManger>();
    }

    //called before physics updates -- physics should go here
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        bool throwKey = Input.GetButton("Jump");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        //update rotation
        Rotating(moveHorizontal, moveVertical);

        //update throw state
        if(throwKey == true)
        {
            throwInteraction();
        }
    }

    void Rotating (float Horizontal, float Vertical)
    {
        //create a new vector of the horizontal and vertical inputs
        Vector3 targetDirection = new Vector3(Horizontal, 0f, Vertical);

        //create a rotation based on this new vector assuming that up is the global y axis
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

        //create a rotation that is an increment closer to the target rotation from the players rotation
        Quaternion newRotation = Quaternion.Lerp(rb.rotation, targetRotation, turnSmoothing * Time.deltaTime);

        //change the players rotation to the new rotation
        rb.MoveRotation(newRotation);
    }

    #region Triggers
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("resource") && carrying == false)
        {
            ResourePile target = other.GetComponent<ResourePile>();
            //if (target.ready)
            //{
            type = target.type;
            carrying = true;
            
            //}
        }

        if (other.gameObject.CompareTag("pit"))
        {
            atPit = true;
        }
    }

    void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("pit"))
        {
            atPit = false;
        }
    }
    #endregion

    void throwInteraction()
    {
        if (carrying == true && atPit == true)
        {
            //put item into the pit
            pit.addResource(type);
            carrying = false;    

        }
        else if (carrying == true && atPit == false)
        {
            //discard Item
            carrying = false;    
        }
    }

}
