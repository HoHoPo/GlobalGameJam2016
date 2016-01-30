using UnityEngine;
using System.Collections;

public class flyingDemonMovement : demonMovement {

    private bool diving;

    public int diveSpeed;

	// Use this for initialization
	void Start () {
        base.Start();

        diving = false;

        Vector3 tempPos = gameObject.transform.position;
        tempPos.y += 9;
        gameObject.transform.position = tempPos;

	}
	
	// Update is called once per frame
	void Update () {
        if (!diving)
        {
            base.Update();

            Vector3 down = transform.TransformDirection(Vector3.down);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, down, out hit))
            {
                if (hit.collider.tag == "demon")
                {
                    diving = true;
                }
            }
        }
        else
        {
            transform.Translate(Vector3.down * diveSpeed * Time.deltaTime);
        }
        Debug.Log("still alive");

	}

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
