﻿using UnityEngine;
using System.Collections;

public class demonMovement : MonoBehaviour
{

    public float speed;
    public bool moving;

    public GameObject targetPoint;

    public int team;
    public string enemyPitName;

    private bool frontline;

    // Use this for initialization
    protected void Start()
    {
        moving = true;
        frontline = false;

    }

    // Update is called once per frame
    protected void Update()
    {
        if (moving)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

    }

    void OnTriggerEnter(Collider col)
    {
        var combat = gameObject.GetComponent<demonCombat>();
        if (col.gameObject.tag == "demon")
        {
            //team information is in movement. Probably shouldn't be?
            var enemyMovement = col.gameObject.GetComponent<demonMovement>();


            if (enemyMovement.team != team)
            {
                moving = false;
                frontline = true;
                combat.beginCombat(col.gameObject);
            }
            else if (!frontline)
            {
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
        if (col.gameObject.tag == "demon")
        {
            var enemyMovement = col.gameObject.GetComponent<demonMovement>();
            if (enemyMovement.team == team)
            {
                moving = true;
            }
        }
    }
}
