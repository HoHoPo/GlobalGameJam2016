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
        { "sle", new SummonImp() },
        { "eleg", new Metor() },
        { "slee", new SummonDevil() },
        {"iig",new slow() },
        {"ssie", new SummonBomber() }
    };
}


public interface RitualAction
{
    void Ritual(pitManger playerPit);
    bool isCast();
}

#region RitualActions
public class Metor : RitualAction
{

    private bool _cast = false;
    public Metor()
    {

    }

    public void Ritual(pitManger playerPit)
    {
        playerPit.SummonMeteor();
        _cast = true;

    }
    public bool isCast()
    {
        return _cast;
    }
}

public class slow :  RitualAction
{
    private bool _cast = false;
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
        _cast = true;
    }
    public bool isCast()
    {
        return _cast;
    }
}

public class SummonDevil :  RitualAction
{
    private bool _cast = false;
    public SummonDevil()
    {

    }

    public void Ritual(pitManger playerPit)
    {
        playerPit.GetComponent<spawnDemon>().SpawnDevil(playerPit.TeamID);
        _cast = true;
    }
    public bool isCast()
    {
        return _cast;
    }
}

public class SummonImp :  RitualAction
{
    private bool _cast = false;
    public SummonImp()
    {

    }

    public void Ritual(pitManger playerPit)
    {
        playerPit.GetComponent<spawnDemon>().SpawnImp(playerPit.TeamID);
        _cast = true;
    }
    public bool isCast()
    {
        return _cast;
    }
}

public class SummonBomber :  RitualAction
{
    private bool _cast = false;
    public SummonBomber()
    {

    }

    public void Ritual(pitManger playerPit)
    {
        playerPit.GetComponent<spawnDemon>().SpawnFlying(playerPit.TeamID);
        _cast = true;
    }
    public bool isCast()
    {
        return _cast;
    }
}
#endregion