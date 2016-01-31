using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class randRituals : MonoBehaviour {

    public Dictionary<string, string> myRituals;
    // Use this for initialization
    void Start () {
        foreach (string key in resouceManager.resourcePatterns.Keys)
        {
            // The random number sequence
            System.Random num = new System.Random();

            // Create new string from the reordered char array
            string rand = new string(key.ToCharArray().
                OrderBy(s => (num.Next(2) % 2) == 0).ToArray());
            myRituals.Add(rand, key);
        }


    }
}
