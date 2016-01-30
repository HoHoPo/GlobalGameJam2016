using UnityEngine;
using System.Collections;

public class demonMovement : MonoBehaviour {

    public float speed;
    public bool moving;

    public GameObject targetPoint;

    public int team;
    public string enemyPitName;

	// Use this for initialization
	void Start () {
        moving = true;
	
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
        
        if (col.gameObject == targetPoint)
        {
            this.moving = false;
            //var enemyPit = GameObject.Find(enemyPitName);
            
        }

    }
}
