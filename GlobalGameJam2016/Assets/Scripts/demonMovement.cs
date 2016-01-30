using UnityEngine;
using System.Collections;

public class demonMovement : MonoBehaviour {

    float speed; 

	// Use this for initialization
	void Start () {
        

        switch (gameObject.name)
        {
            case "devil":
                speed = 5;
                break;
            case "imp":
                speed = 10;
                break;
            default:
                break;
        }
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	
	}

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("moo");
        switch (col.gameObject.name)
        {
            case "devil":
                Debug.Log("col");
                break;
            default:
                break;
        }
    }
}
