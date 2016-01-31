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

    public static Dictionary<string, RitualAction> resourcePatterns = new Dictionary<string, RitualAction>
    {
        { "sllls", new SummonDevil() },
        { "elelg", new Metor() },
        { "sleig", new SummonDevil() },
        {"iiseg",new slow() },
        {"sesls", new SummonBomber() }
    };
}


public interface RitualAction
{

    void Ritual(pitManger playerPit);

}

#region RitualActions
public class Metor : MonoBehaviour, RitualAction
{
    public Metor()
    {

    }

    public void Ritual(pitManger playerPit)
    {
        playerPit.SummonMeteor();
    }
}

public class slow : MonoBehaviour, RitualAction
{
    public slow()
    {

    }

    public void Ritual(pitManger playerPit)
    {

        GameObject[] otherTeam;
        if (playerPit.TeamID == 0)
        {
            otherTeam = GameObject.FindGameObjectsWithTag("Team2");
            foreach (GameObject player in otherTeam)
            {
                player.GetComponent<playersMovement>().slowed = true;
            }
        }
        else if (playerPit.TeamID == 1)
        {
            otherTeam = GameObject.FindGameObjectsWithTag("Team1");
            foreach (GameObject player in otherTeam)
            {
                player.GetComponent<playersMovement>().slowed = true;
            }
        }
    }
}

public class SummonDevil : MonoBehaviour, RitualAction
{
    public SummonDevil()
    {

    }

    public void Ritual(pitManger playerPit)
    {
        playerPit.GetComponent<spawnDemon>().SpawnDevil(playerPit.TeamID);
    }
}

public class SummonImp : MonoBehaviour, RitualAction
{
    public SummonImp()
    {

    }

    public void Ritual(pitManger playerPit)
    {
        playerPit.GetComponent<spawnDemon>().SpawnImp(playerPit.TeamID);
    }
}

public class SummonBomber : MonoBehaviour, RitualAction
{
    public SummonBomber()
    {

    }

    public void Ritual(pitManger playerPit)
    {
        playerPit.GetComponent<spawnDemon>().SpawnFlying(playerPit.TeamID);
    }
}
#endregion