using UnityEngine;
using System.Collections;

public class demonCombat : MonoBehaviour {

    public int hitpoints;
    public int damage;
    public float attackSpeed;
    public float dieTime;

    public bool alive;
    public ParticleSystem explosion;

    private bool inCombat;

    private float timer;

    protected GameObject curEnemy;


	// Use this for initialization
	void Start () {
        alive = true;
        inCombat = false;
        dieTime = 0;

        curEnemy = null;
	
	}

    public void beginCombat(GameObject enemy)
    {
        
        inCombat = true;
        timer = attackSpeed;

        curEnemy = enemy;

        attack();
    }

    public void attack()
    {
        
        var enemyCombat = curEnemy.GetComponent<demonCombat>();

        enemyCombat.takeDamage(damage);
        enemyCombat.hitpoints -= damage;

        if (gameObject.name == "bomber")
        {
            AudioSource audio = gameObject.GetComponent<AudioSource>();
            audio.Play();
            Destroy(gameObject, 0.1f);
            Destroy(curEnemy, 0.1f);
            Instantiate(explosion,this.transform.position,this.transform.rotation);
            Debug.Log("boom");

        }
    }

    public void attackPit(string pitName)
    {
        var enemyPit = GameObject.Find(pitName);

        var enemyPitManager = enemyPit.GetComponent<pitManger>();

        enemyPitManager.takeDamage(damage);
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
         //   this.gameObject.GetComponent<Renderer>().enabled = false;
            Destroy(gameObject, 1);
            
            AudioSource audio = GetComponent<AudioSource>();
            if (!audio.isPlaying && curEnemy.name != "bomber")
            {
                audio.Play();
            }
            
        }

       






    }
}
