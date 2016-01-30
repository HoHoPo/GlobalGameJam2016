using UnityEngine;
using System.Collections;

public class demonMovement : MonoBehaviour
{

    public float speed;
    public bool moving;

    public GameObject targetPoint;

    public int team;
    public string enemyPitName;

    // Use this for initialization
    void Start()
    {
        moving = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

    }

    void OnTriggerEnter(Collider col)
    {
        var combat = gameObject.GetComponent<demonCombat>();
        if (col.gameObject.name == "devil" || col.gameObject.name == "imp")
        {
            //team information is in movement. Probably shouldn't be?
            var enemyMovement = col.gameObject.GetComponent<demonMovement>();
            if (enemyMovement.team != team)
            {
                moving = false;
                combat.beginCombat(col.gameObject);
            }
            else
            {
                Debug.Log("djfhasdl");
                moving = false;
            }


        }

        if (col.gameObject == targetPoint)
        {
            this.moving = false;
            combat.attackPit(enemyPitName);


        }

    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "devil" || col.gameObject.name == "imp")
        {
            var enemyMovement = col.gameObject.GetComponent<demonMovement>();
            if (enemyMovement.team != team)
            {
                moving = true;
            }
        }
    }
}
