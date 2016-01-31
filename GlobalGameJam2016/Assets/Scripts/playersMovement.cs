using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class playersMovement : MonoBehaviour
{
    public enum controls
    {
        keyboard,
        joystick1,
        joystick2,
        joystick3,
        joystick4
    };

    //public
    public float setspeed =10f;
    public float slowTime = 4f;
    public float turnSmoothing = 15f;
    public controls PlayerControls;
    private bool _slowed = false;
    //efects
    public bool slowed
    {
        get
        {
            return _slowed;
        }
        set
        {

            if (value == true)
            {
                speed = setspeed / 2;
                slowTimer = Time.time;
            }
            else if (value == false)
            {
                speed = setspeed;
            }
                _slowed = value;
        }
    }

    [SerializeField]
    private pitManger pit;
    [SerializeField]
    private GameObject teamArea;

    //private
    private bool carrying = false;
    private float speed = 10f;
    private float slowTimer;
    private resouceManager.resourceType type;
    private bool atPit = false;
    private Rigidbody rb;
    private float xMin, yMin, xMax, yMax;
	GameObject carryingObject;

    // Use this for initialization
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        xMax = teamArea.transform.localPosition.x + teamArea.transform.localScale.x/2;
        yMax = teamArea.transform.localPosition.z + teamArea.transform.localScale.z/2;
        xMin = teamArea.transform.localPosition.x - teamArea.transform.localScale.x/2;
        yMin = teamArea.transform.localPosition.z - teamArea.transform.localScale.z/2;

        speed = setspeed;
        slowTimer = Time.time;

    }

    //called before physics updates -- physics should go here
    void FixedUpdate()
    {
        if(Input.GetButton("Restart")){
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
        if (Input.GetButton("Cancel"))
        {
            Application.Quit();
        }

        float moveHorizontal;
        float moveVertical;
        bool throwKey;
        bool discardKey;
        switch (PlayerControls)
        {
            case controls.joystick1:
                moveHorizontal = Input.GetAxis("HorizontalJoy1");
                moveVertical = Input.GetAxis("VerticalJoy1");
                throwKey = Input.GetButton("UseCircleJoy1");
                discardKey = Input.GetButton("BJoy1");
                break;
            case controls.joystick2:
                moveHorizontal = Input.GetAxis("HorizontalJoy2");
                moveVertical = Input.GetAxis("VerticalJoy2");
                throwKey = Input.GetButton("UseCircleJoy2");
                discardKey = Input.GetButton("BJoy2");
                break;
            case controls.joystick3:
                moveHorizontal = Input.GetAxis("HorizontalJoy3");
                moveVertical = Input.GetAxis("VerticalJoy3");
                throwKey = Input.GetButton("UseCircleJoy3");
                discardKey = Input.GetButton("BJoy3");
                break;
            case controls.joystick4:
                moveHorizontal = Input.GetAxis("HorizontalJoy4");
                moveVertical = Input.GetAxis("VerticalJoy4");
                throwKey = Input.GetButton("UseCircleJoy4");
                discardKey = Input.GetButton("BJoy4");
                break;
            default:
                moveHorizontal = Input.GetAxis("Horizontal");
                moveVertical = Input.GetAxis("Vertical");
                throwKey = Input.GetButton("UseCircle");
                discardKey = Input.GetButton("bButton");
                break;
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        if (teamArea != null)
        {
            rb.position = new Vector3(

                Mathf.Clamp(rb.position.x, xMin, xMax),
                rb.position.y,
                Mathf.Clamp(rb.position.z, yMin, yMax)
                );
        }

        // If there is some axis input...
        if (moveHorizontal != 0f || moveVertical != 0f)
        {
            //update rotation
            Rotating(moveHorizontal, moveVertical);
        }


        //update throw state
        if (throwKey == true && carrying == true && atPit == true)
        {
            pit.addResource(type);
            carrying = false;
			if (carryingObject != null) {
				Destroy (carryingObject);
				carryingObject = null;
			}

        }
        if (discardKey==true && carrying == true && atPit == false)
        {
            //discard Item
            carrying = false;
			if (carryingObject != null) {
				Destroy (carryingObject);
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();

			}
        }

        if ((Time.time - slowTimer) >= slowTime)
        { 
                slowed = false;
          
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
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("resource") && carrying == false)
        {
            ResourePile target = other.gameObject.GetComponent<ResourePile>();
            if (target.ready)
            {
            type = target.type;
            carrying = true;
			if (target.pickupPrefab != null) {
				GameObject pickup = GameObject.Instantiate (target.pickupPrefab);
				pickup.transform.parent = this.transform;
				carryingObject = pickup;
			}
                target.ready = false;
            
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("pit"))
        {
            atPit = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("pit"))
        {
            atPit = false;
        }
    }
    #endregion
}


