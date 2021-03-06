﻿using UnityEngine;
using System.Collections;

////resource disks
//[System.Serializable]
//public class shirnk
//{
//    public float maxScale, minScale;
//    public GameObject disk;

//}

public class ResourePile : MonoBehaviour {

    public resouceManager.resourceType type;
    //The prefab given to the player when they pickup this type
    public GameObject pickupPrefab;
    public bool infinte = true;
    public double respawnSeconds = 2;
    private double timeoff = -1;
    public GameObject ringprefab;
    private bool visual = false;

    //public shirnk shirnkage;
    //private GameObject disk;

    private bool _ready = true;
    public bool ready
    {
        get { return _ready; }
        set
        {
            _ready = value;
            if(infinte == true)
            {
                _ready = true;
            }
            if (value == false)
            {
                timeoff = Time.time;
                
            }
        }
    }
	
	//// Use this for initialization
	void Start () {

        this.gameObject.tag = ("resource");
	}

    //Update is called once per frame

    void Update()
    {
        if (ready == false)
        {
            if (!visual)
            {

                Instantiate(ringprefab,this.transform.position+ new Vector3(0f,.5f,0f),this.transform.rotation);
            }
            visual = true;
            // run visual
            if (timeoff > 0)
            {
                if ((Time.time - timeoff) > respawnSeconds)
                {
                    ready = true;
                    visual = false;
                    timeoff = -1;
                    //   turn off visual
                }
            }
        }
    }

    resouceManager.resourceType takeResource( ref bool carry)
    {
        carry = ready;
        return type;
    }

}
