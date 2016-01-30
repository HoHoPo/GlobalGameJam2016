using UnityEngine;
using System.Collections;

public class spawnDemon : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Vector3 position = gameObject.transform.position;
        if (gameObject.name == "Team1Pit")
        {

            GameObject demon = (GameObject)Instantiate(Resources.Load("devilprefab"), position, Quaternion.Euler(0, 270, 0));
 
            demon.name = "devil";
        } else if (gameObject.name == "Team2Pit")
        {
            GameObject demon = (GameObject)Instantiate(Resources.Load("impprefab"), position, Quaternion.Euler(0, 90, 0));
            demon.name = "devil";
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
