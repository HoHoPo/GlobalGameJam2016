using UnityEngine;
using System.Collections;

public class titlescreen : MonoBehaviour {
    //just stealing code from playersMovement
    public enum controls
    {
        keyboard,
        joystick1,
        joystick2,
        joystick3,
        joystick4
    };

    public controls PlayerControls;



    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("UseCircleJoy1") || Input.GetButtonDown("UseCircleJoy2") || Input.GetButtonDown("UseCircleJoy3") || 
            Input.GetButtonDown("UseCircleJoy4") || Input.GetButtonDown("UseCircle"))
        {
            Application.LoadLevel("MainScene");
        }
        {
            Debug.Log("moo");
        }
	
	}
}
