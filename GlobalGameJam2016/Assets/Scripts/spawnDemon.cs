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
            demon.name = "imp";
        }

    }

	public GameObject SpawnDevil(int teamID){
		Vector3 position = gameObject.transform.position;

		GameObject demon = (GameObject)Instantiate(Resources.Load("devilprefab"));
		demon.transform.position=position;
		demon.name = "devil";

		if (teamID == 0) {
				demon.transform.rotation = Quaternion.Euler(0, 270, 0);
		}
		if(teamID == 1){
				demon.transform.rotation = Quaternion.Euler(0, 90, 0);
		}

		return demon;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
