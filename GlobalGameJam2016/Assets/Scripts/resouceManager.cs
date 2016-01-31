using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class resouceManager : MonoBehaviour {

	public enum resourceType
    {
        skull = 's',
        lava = 'l',
		gold = 'g',
		ice = 'i',
		earth = 'e'
    };

    public static Dictionary<string, bool> resourcePatterns = new Dictionary<string, bool>
    {
        { "sllls",true },
		{ "elelg", true },
		{ "sleig", true },
        {"iiseg",true },
        {"sesls", true }
        

    };
	
	// Update is called once per frame
	void Update () {
	
	}
}
