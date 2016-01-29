using UnityEngine;
using System.Collections;

public class playerResource : MonoBehaviour {

    public bool carrying = false;
    private combinationManager.resourceType type;
    public bool atPit = false;

    void OnTriggerEnter( Collider other)
    {
        if (other.gameObject.CompareTag("resource") && carrying == false)
        {
            ResourePile target = other.GetComponent<ResourePile>();
           //if (target.ready)
            //{
                type = target.type;
            //}
        }

        if(other.gameObject.CompareTag("pit"))
        {
            atPit = true;
        }
    }

    void onTriggerLeave (Collider other)
    {

        if (other.gameObject.CompareTag("pit"))
        {
            atPit = false;
        }
    }

    void drop()
    {
        carrying = false;
    }
}
