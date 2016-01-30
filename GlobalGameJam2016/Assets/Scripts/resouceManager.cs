using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class resouceManager : MonoBehaviour {

	public enum resourceType
    {
        skull = 's',
        lava = 'l'
    };

    public static Dictionary<string, bool> resourcePatterns = new Dictionary<string, bool>
    {
        { "sls" ,true },
        { "sllls",true }
        

    };
	
	// Update is called once per frame
	void Update () {
	
	}
}
