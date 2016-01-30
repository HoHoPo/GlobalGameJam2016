using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class pitManger : MonoBehaviour {


    private string inPit;
    public Text pitResourcesText;
	public List<GameObject> meteorTargets;
	public GameObject MeteorPrefab;

	private List<bool> hasMeteor;
	// Use this for initialization
	void Start () {
        pitResourcesText.text = "pit has nothing";
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
				break;
			default:
				break;
			}

            inPit = "";
        }
        pitTextUpdate();
    }

	public void SummonMetoer(){
		int numTargets = meteorTargets.Count;
		int Target = Random.RandomRange (0, numTargets - 1);
		GameObject currentTarget = meteorTargets [Target];
		int numAttempts = 0;
		while (numAttemps < numTargets) {
			if (hasMeteor [Target] == false) {
				GameObject.Instantiate(MeteorPrefab,
			}
		}

	}

    public void pitTextUpdate()
    {

        pitResourcesText.text = "InPit :" + inPit;
    }
}
