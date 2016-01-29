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
            //summon thingy
            inPit = "";
            pitTextUpdate();
        }
        pitTextUpdate();
    }

    public void pitTextUpdate()
    {

        pitResourcesText.text = "InPit :" + inPit;
    }
}
