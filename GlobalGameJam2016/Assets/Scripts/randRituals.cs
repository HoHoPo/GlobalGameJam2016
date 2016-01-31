using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class randRituals : MonoBehaviour {

    public Dictionary<string, string> myRituals;
    // Use this for initialization
    public void Start() {
        myRituals = new Dictionary<string, string>();
        foreach (string key in resouceManager.resourcePatterns.Keys)
        {
            string rand = "";
            int matches = 1;
            while (matches != 0)
            {
                // The random number sequence
                System.Random num = new System.Random();

                // Create new string from the reordered char array
                rand = new string(key.ToCharArray().
                    OrderBy(s => (num.Next(2) % 2) == 0).ToArray());
                matches = 0;
                IEnumerable resourceEnumerable = myRituals.Keys.Where(currentKey => currentKey.StartsWith(rand));
                foreach (string currentKey in resourceEnumerable)
                {
                    matches++;
                    //break;
                }
            }
            myRituals.Add(rand, key);
        }


    }
}
