using UnityEngine;
using System.Collections;

public class spawnDemon : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Vector3 position = gameObject.transform.position;
        if (gameObject.name == "Team1Pit")
		{
			GameObject demon = SpawnDevil (0);
        } else if (gameObject.name == "Team2Pit")
        {
			GameObject demon = SpawnDemon (1, "imp");
        }

    }

	public GameObject SpawnDevil(int teamID){

		return SpawnDemon (teamID, "devil");

	}

	public GameObject SpawnImp(int teamID){
		return SpawnDemon (teamID, "imp");
	}

	public GameObject SpawnDemon(int teamID, string DemonType){
		Vector3 position = gameObject.transform.position;

		GameObject demon = (GameObject)Instantiate(Resources.Load(DemonType+"prefab"));
		demon.transform.position=position;

		demon.name = DemonType;

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
