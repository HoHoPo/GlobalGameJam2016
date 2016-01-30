using UnityEngine;
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
	public bool infinte = true;
    public double respawnSeconds = 2;
    private double timeoff = 0;

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
    // Use this for initialization
    void Start()
    {

        this.gameObject.tag = ("resource");
	}

    //Update is called once per frame

    void Update()
    {
        if (ready == false)
        {

           // diskScale(Time.time - timeoff / respawnSeconds, true);
            if ((Time.time - timeoff) > respawnSeconds)
            {
                ready = true;
             //   diskScale(Time.time - timeoff / respawnSeconds, true);
            }
        }
    }

    resouceManager.resourceType takeResource( ref bool carry)
    {
        carry = ready;
        return type;
    }

}
