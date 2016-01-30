using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class pitManger : MonoBehaviour {


    private string inPit;
    public Text pitResourcesText;

	// Use this for initialization
	void Start () {
        pitResourcesText.text = "pit has nothing";
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

    public void pitTextUpdate()
    {

        pitResourcesText.text = "InPit :" + inPit;
    }
}
