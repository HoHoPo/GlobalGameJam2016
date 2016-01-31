using UnityEngine;
using System.Collections;

public class Cooldown_ring : MonoBehaviour {
    public float cd = 5f;
   

    private float timer;
	// Use this for initialization
	void Start () {
        timer = Time.time;

    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time- timer >= cd) {
            Destroy(this.gameObject);
        }
	}
}
