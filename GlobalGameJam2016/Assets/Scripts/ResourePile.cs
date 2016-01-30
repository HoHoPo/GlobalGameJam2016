using UnityEngine;
using System.Collections;

public class ResourePile : MonoBehaviour {

    public resouceManager.resourceType type;

	//The prefab given to the player when they pickup this type
	public GameObject pickupPrefab;
	//public bool infinte = true;
	//public double probSpawnPerSecond = 0.5;
	//private double timeoff = 0;

	//private bool _ready = true;
	//public bool ready
	//{
	//	get { return _ready; }
	//	set
	//	{
	//		_ready = value;
	//		if (value == false)
	//		{
	//			timeoff = Time.time;
	//		}
	//	}
	//}
	//// Use this for initialization
	void Start () {

        this.gameObject.tag = ("resource");
	}
	
	// Update is called once per frame
	//void Update () {
	//	if( ready == false)
	//	{
	//		if (Random.value <(Time.time - timeoff) * probSpawnPerSecond)
	//		{
	//			ready = true;
	//		}
	//	}
	//}

}
