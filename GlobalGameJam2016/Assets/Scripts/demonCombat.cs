using UnityEngine;
using System.Collections;

public class demonCombat : MonoBehaviour {

    public int hitpoints;
    public int damage;
    public float attackSpeed;

    private float timer;


	// Use this for initialization
	void Start () {

	
	}

    public void beginCombat()
    {
        timer = attackSpeed;

        attack();
    }

    void attack()
    {

    }
	
	// Update is called once per frame
	void Update () {

	
	}
}
