using UnityEngine;
using System.Collections;

public class destroyself : MonoBehaviour {
    public float delay =2f;
    private float timer;
	// Use this for initialization
	void Start () {
        timer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time - timer >= delay)
        {
            Debug.Log("this died");
            Destroy(this.gameObject);
        }
	}
}
