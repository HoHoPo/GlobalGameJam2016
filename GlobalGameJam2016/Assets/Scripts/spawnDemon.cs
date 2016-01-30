using UnityEngine;
using System.Collections;

public class spawnDemon : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (gameObject.name == "Team1")
        {
            GameObject demon = (GameObject)Instantiate(Resources.Load("devilprefab"), gameObject.transform.position, Quaternion.Euler(0, 270, 0));
            var boxCol = demon.AddComponent<BoxCollider>();
 
            demon.name = "devil";
        } else if (gameObject.name == "Team2")
        {
            GameObject demon = (GameObject)Instantiate(Resources.Load("devilprefab"), gameObject.transform.position, Quaternion.Euler(0, 90, 0));
            demon.AddComponent<BoxCollider>();
            demon.name = "devil";
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
