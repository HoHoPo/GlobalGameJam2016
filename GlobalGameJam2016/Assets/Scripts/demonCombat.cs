using UnityEngine;
using System.Collections;

public class demonCombat : MonoBehaviour {

    public int hitpoints;
    public int damage;
    public float attackSpeed;

    public bool alive;

    private bool inCombat;

    private float timer;

    private GameObject curEnemy;


	// Use this for initialization
	void Start () {
        alive = true;
        inCombat = false;

        curEnemy = null;
	
	}

    public void beginCombat(GameObject enemy)
    {
        inCombat = true;
        timer = attackSpeed;

        curEnemy = enemy;

        attack();
    }

    void attack()
    {
        var enemyCombat = curEnemy.GetComponent<demonCombat>();

        enemyCombat.takeDamage(damage);
        enemyCombat.hitpoints -= damage;


  /*      if (!enemyCombat.alive || curEnemy ==null)
        {
            curEnemy = null;

            demonMovement movement = gameObject.GetComponent<demonMovement>();

            movement.moving = true;

        }*/
    }

    public void takeDamage(int amount)
    {
        hitpoints -= amount;
        

        if (hitpoints <= 0)
        {
            alive = false;
        }
    }
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;

        if (inCombat && curEnemy == null)
        {
            demonMovement movement = gameObject.GetComponent<demonMovement>();

            movement.moving = true;
            inCombat = false;
        }

        if (timer <= 0 && curEnemy != null)
        {
            attack();

            
        }
        if (!alive)
        {
            Destroy(gameObject, 1);
        }

       






    }
}
