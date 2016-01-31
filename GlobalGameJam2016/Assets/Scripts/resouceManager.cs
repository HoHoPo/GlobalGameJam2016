using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class resouceManager : MonoBehaviour {

    public delegate void castEvent(bool _isCast);
    public enum resourceType
    {
        skull = 's',
        lava = 'l',
		gold = 'g',
		ice = 'i',
		earth = 'e'
    };

    public static Dictionary<string, RitualAction> resourcePatterns = new Dictionary<string, RitualAction>
    {
        { "sle", new SummonImp() },
        { "ilg", new Metor() },
        { "slei", new SummonDevil() },
        {"iig",new slow() },
        {"slll", new SummonBomber() }
    };
}


public interface RitualAction
{
    event resouceManager.castEvent isCast;
    void Ritual(pitManger playerPit);
 //   bool isCast();
}

#region RitualActions
public class Metor : RitualAction
{
    public event resouceManager.castEvent isCast;
    
    public Metor()
    {

    }

    public void Ritual(pitManger playerPit)
    {
        playerPit.SummonMeteor();
        isCast(true);

    }
}

public class slow :  RitualAction
{

    public event resouceManager.castEvent isCast;
    public slow()
    {

    }

    public void Ritual(pitManger playerPit)
    {

        GameObject[] otherTeam;
        if (playerPit.TeamID == 1)
        {
            otherTeam = GameObject.FindGameObjectsWithTag("Team2");
            foreach (GameObject player in otherTeam)
            {
                player.GetComponent<playersMovement>().slowed = true;
            }
        }
        else if (playerPit.TeamID == 0)
        {
            otherTeam = GameObject.FindGameObjectsWithTag("Team1");
            foreach (GameObject player in otherTeam)
            {
                player.GetComponent<playersMovement>().slowed = true;
            }
        }
        isCast(true);
    }
}

public class SummonDevil :  RitualAction
{ 
    public event resouceManager.castEvent isCast;
    public SummonDevil()
    {

    }

    public void Ritual(pitManger playerPit)
    {
        playerPit.GetComponent<spawnDemon>().SpawnDevil(playerPit.TeamID);
        isCast(true);
    }
}

public class SummonImp :  RitualAction
{ 
    public event resouceManager.castEvent isCast;
    public SummonImp()
    {

    }

    public void Ritual(pitManger playerPit)
    {
        playerPit.GetComponent<spawnDemon>().SpawnImp(playerPit.TeamID);
        isCast(true);
    }
}

public class SummonBomber :  RitualAction
{

        public event resouceManager.castEvent isCast;
        public SummonBomber()
    {

    }

    public void Ritual(pitManger playerPit)
    {
        playerPit.GetComponent<spawnDemon>().SpawnFlying(playerPit.TeamID);
            isCast(true);
    }
}
#endregion