using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class pitManger : MonoBehaviour {


    private string inPit;
    public Text pitResourcesText;
    public GameObject ProgressObject;
    private List<GameObject> lights = new List<GameObject>(); 

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
        double matches = 0;
        IEnumerable resourceEnumerable = resouceManager.resourcePatterns.Keys.Where(currentKey => currentKey.StartsWith(inPit));
        foreach (string currentKey in resourceEnumerable)
        {
            matches++;
            break;
        }

        if (resouceManager.resourcePatterns.ContainsKey(inPit))
        {

			switch (inPit) {
			case "sls":
				Debug.Log ("We summoned SKULL LAVA SKULL");
				break;
			default:
				break;
			}

            //summon thingy
            inPit = "";

        }
        else if(matches == 0)
        {
            inPit = "";
        }

        manageLights(inPit.Count());
        pitTextUpdate();
    }

    public void pitTextUpdate()
    {

        pitResourcesText.text = "InPit :" + inPit;
    }
    public void manageLights(double lightCount)
    {
        double diffrence = lights.Count - lightCount;
        if (diffrence > 0) //remove a light
        {
            for (int i = 0; i < diffrence; i++)
            {
                Destroy(lights[lights.Count-1]);
                lights.RemoveAt(lights.Count - 1);
            }
        }
        else if(diffrence < 0) //add a light
        {
            Vector3 temp = this.gameObject.transform.position;
            temp.y += 4;
            switch (lights.Count())
            {
                case 0:
                    temp.z += this.transform.localScale.z;
                    break;
                case 1:

                    temp.x += this.transform.localScale.x;
                    break;
                case 2:

                    temp.z -= this.transform.localScale.z;
                    break;
                case 3:

                    temp.x -= this.transform.localScale.x;
                    break;
                default:
                    break;
            }
            lights.Add((GameObject)( Instantiate(ProgressObject, temp, new Quaternion(0,0,0,0))));

        }
    }
}
