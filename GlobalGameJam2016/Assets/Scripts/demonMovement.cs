using UnityEngine;
using System.Collections;

public class demonMovement : MonoBehaviour {

    public float speed;
    public bool moving;

    

	// Use this for initialization
	void Start () {
        moving = true;

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
        if (moving)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "devil" || col.gameObject.name == "imp")
        {
            moving = false;
            var combat = gameObject.GetComponent<demonCombat>();
            combat.beginCombat(col.gameObject);     
        }

    }
}
