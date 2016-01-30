using UnityEngine;
using System.Collections;

public class spawnDemon : MonoBehaviour {

	// Use this for initialization
	void Start () {

        if (gameObject.name == "Team1Pit")
        {

			GameObject demon = SpawnDevil (0);
        } else if (gameObject.name == "Team2Pit")
        {
			GameObject demon = SpawnDemon (1, "imp");
        }

    }

	public GameObject SpawnDevil(int teamID){
		/*Vector3 position = gameObject.transform.position;

		GameObject demon = (GameObject)Instantiate(Resources.Load("devilprefab"));
		demon.transform.position=position;
		demon.name = "devil";

		if (teamID == 0) {
				demon.transform.rotation = Quaternion.Euler(0, 270, 0);
		}
		if(teamID == 1){
				demon.transform.rotation = Quaternion.Euler(0, 90, 0);
		}

		return demon;*/
		return SpawnDemon (teamID, "devil");

	}

	public GameObject SpawnDemon(int teamID, string DemonType){
		Vector3 position = gameObject.transform.position;

		GameObject demon = (GameObject)Instantiate(Resources.Load(DemonType+"prefab"));

		demon.name = DemonType;

        GameObject spawnPoint;
        var movement = demon.GetComponent<demonMovement>();

        if (teamID == 0) {
            spawnPoint = GameObject.Find("team_2 demonspawn");
            demon.transform.position = spawnPoint.transform.position;
			demon.transform.rotation = Quaternion.Euler(0, 90, 0);

            movement.targetPoint = GameObject.Find("team_1 demonspawn");
            movement.enemyPitName = "Team1Pit";
           

        }
		if(teamID == 1){
            spawnPoint = GameObject.Find("team_1 demonspawn");
            demon.transform.position = spawnPoint.transform.position;
            demon.transform.rotation = Quaternion.Euler(0, 270, 0);

            movement.targetPoint = GameObject.Find("team_2 demonspawn");
            movement.enemyPitName = "Team2Pit";
		}

        movement.team = teamID;

		return demon;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
