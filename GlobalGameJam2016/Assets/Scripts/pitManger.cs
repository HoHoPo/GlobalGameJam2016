using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class pitManger : MonoBehaviour {


    private string inPit;
    public Text pitResourcesText;
	public List<GameObject> meteorTargets;
	public GameObject MeteorPrefab;
	public int TeamID;
	private List<bool> hasMeteor;
	private spawnDemon DemonSpawner;
	// Use this for initialization
	void Start () {
        pitResourcesText.text = "pit has nothing";
		DemonSpawner = this.GetComponent<spawnDemon> ();

		hasMeteor = new List<bool> ();
		//Initialize meteor tracking
		for (int i = 0; i < meteorTargets.Count; i++) {
			hasMeteor.Add (false);
		}
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void addResource(resouceManager.resourceType newResource)
    {
        inPit += (char)(newResource);
        //if()
        if (resouceManager.resourcePatterns.ContainsKey(inPit))
        {

			switch (inPit) {
			case "sleig":
				Debug.Log ("We summoned SKULL LAVA SKULL");

				break;
			case "elelg":
				Debug.Log ("We summoned a Meteor");
				SummonMeteor ();
				break;
			case "sllll":
				Debug.Log ("We summoned an Imp");
				//SummonMeteor ();
				DemonSpawner.SpawnDevil(this.TeamID);
				break;
			default:
				break;
			}

            inPit = "";
        }
        pitTextUpdate();
    }

	public void SummonMeteor(){
		int numTargets = meteorTargets.Count;
		//int Target = Random.RandomRange (0, numTargets - 1);
		//GameObject currentTarget = meteorTargets [Target];

		int numAttempts = 0;
		bool foundEmpty = false;

		//Pick one until we find an empty one.
		while (numAttempts < numTargets && foundEmpty == false) {
			int Target = Random.Range (0, numTargets - 1);
			GameObject currentTarget = meteorTargets[Target];
			if (hasMeteor [Target] == false) {
				GameObject newMeteor = GameObject.Instantiate (MeteorPrefab) as GameObject;
				newMeteor.transform.position = currentTarget.transform.position;
				hasMeteor [Target] = true;
				foundEmpty = true;
			}
			numAttempts++;
		}

	}

    public void pitTextUpdate()
    {

        pitResourcesText.text = "InPit :" + inPit;
    }
}
