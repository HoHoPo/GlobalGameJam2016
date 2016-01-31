using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class pitManger : MonoBehaviour
{


    private string inPit = "";
    public Text pitResourcesText;
    public Canvas GameOver;
    public GameObject ProgressObject;
    public float ProgressObjectHeight = 1;
    public int health = 1;
    private List<GameObject> lights = new List<GameObject>();
    public List<GameObject> meteorTargets;
    public GameObject MeteorPrefab;
    public int TeamID;
    private List<bool> hasMeteor;
    public pitManger EnemyPit;
    public ParticleSystem wrongSequence;

    public double lightDelay = 2;
    private double lightTimerStart = -1;
    private int playersInside = 0;
    private string resouceName = "";

    private randRituals rituals;

    // Use this for initialization
    void Start()
    {
        pitResourcesText.text = "pit has nothing";

        hasMeteor = new List<bool>();

        //Initialize meteor tracking
        for (int i = 0; i < meteorTargets.Count; i++)
        {
            hasMeteor.Add(false);
        }
        rituals = GameObject.FindGameObjectWithTag("GameController").GetComponent<randRituals>();
        
    }
    // Update is called once per frame
    void Update()
    {
        if(lightTimerStart > 0)
        {
            if (Time.time - lightTimerStart > lightDelay)
            {
                turnOnLight();
                lightTimerStart = -1;
            }
        }
    }

    public void addResource(resouceManager.resourceType newResource)
    {
        inPit += (char)(newResource);
        double matches = 0;
        IEnumerable resourceEnumerable = rituals.myRituals.Keys.Where(currentKey => currentKey.StartsWith(inPit));
        foreach (string currentKey in resourceEnumerable)
        {
            matches++;
            //break;
        }
        string Key; 
        if(rituals.myRituals.TryGetValue(inPit, out Key))
        {
            RitualAction Action;
            if (resouceManager.resourcePatterns.TryGetValue(inPit, out Action))
            {
                Action.Ritual(this);

            }
        }        
        else if (matches == 0)
        {
            inPit = "";
            //Trigger out particle
            if (wrongSequence != null)
            {
				wrongSequence.Stop();
                wrongSequence.Play();
            }
        }

        manageLights(inPit.Count());
        pitTextUpdate();
    }

    public void SummonMeteor()
    {
        int numTargets = meteorTargets.Count;
        //int Target = Random.RandomRange (0, numTargets - 1);
        //GameObject currentTarget = meteorTargets [Target];

        int numAttempts = 0;
        bool foundEmpty = false;

        //Pick one until we find an empty one.
        while (numAttempts < numTargets && foundEmpty == false)
        {
            int Target = Random.Range(0, numTargets - 1);
            GameObject currentTarget = meteorTargets[Target];
            if (hasMeteor[Target] == false)
            {
                GameObject newMeteor = GameObject.Instantiate(MeteorPrefab) as GameObject;
                newMeteor.transform.position = currentTarget.transform.position;
                hasMeteor[Target] = true;
                foundEmpty = true;
            }
            numAttempts++;
        }

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
                Destroy(lights[lights.Count - 1]);
                lights.RemoveAt(lights.Count - 1);
            }
        }
        else if (diffrence < 0) //add a light
        {
            Vector3 temp = this.gameObject.transform.position;
            temp.y += ProgressObjectHeight;
            switch (lights.Count())
            {
                case 0:
                    temp.z += this.transform.localScale.z / 2;
                    break;
                case 1:

                    temp.x += this.transform.localScale.x / 2;
                    break;
                case 2:

                    temp.z -= this.transform.localScale.z / 2;
                    break;
                case 3:

                    temp.x -= this.transform.localScale.x / 2;
                    break;
                default:
                    break;
            }

            if (ProgressObject != null)
            {
                lights.Add((GameObject)(Instantiate(ProgressObject, temp, new Quaternion(0, 0, 0, 0))));
            }

        }
    }

    public void takeDamage(int amount)
    {
        health -= amount;
        if (health < 0)
        {
            //end game
            GameOver.enabled = true;
        }
    }

    #region Triggers

    void OnTriggerEnter(Collider col)
    {
        //List<GameObject> players = 
        if (col.gameObject.tag == "Team2" || col.gameObject.tag == "Team1")
        {
            playersInside++;
        }
        if (playersInside == 4)
        {
            lightTimerStart = Time.time;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Team2" || col.gameObject.tag == "Team1")
        {
            playersInside--;
            GameObject temp = GameObject.Find(resouceName);
            if (temp != null)
            {
                temp.GetComponentInChildren<Light>().enabled = false;
                //disableTimer
                lightTimerStart = -1;
            }

        }
    }
    #endregion

    void turnOnLight()
    {
        List<string> keys = new List<string>();
        //find a pattern we can make
        IEnumerable resourceEnumerable = resouceManager.resourcePatterns.Keys.Where(currentKey => currentKey.StartsWith(inPit));
        foreach (string currentKey in resourceEnumerable)
        {
            keys.Add(currentKey);
        }
        char chosen = ' ';
        int tempint = Random.Range(0, keys.Count );
        Debug.Log(keys[tempint]);
        chosen = keys[tempint][inPit.Count()];
        Debug.Log(chosen);

        //light up next resource
        resouceName = "";
        if (TeamID == 0)
        {
            resouceName = "team_2 ";
        }
        else if (TeamID == 1)
        {
            resouceName = "team_1 ";
        }
        //find the resource
        resouceName += (resouceManager.resourceType)(chosen);
        Debug.Log(resouceName);
        GameObject temp = GameObject.Find(resouceName);
        if (temp != null)
        {
            Debug.Log("turningOnLight");
            temp.GetComponentInChildren<Light>().enabled = true;
        }
    }
}


