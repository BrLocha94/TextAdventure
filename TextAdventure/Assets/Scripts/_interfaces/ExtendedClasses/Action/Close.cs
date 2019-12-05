using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : MonoBehaviour, Action
{
    private ActionType type = ActionType.CLOSE;

    int outstandingSucces = 10;
    int successRate = 50;
    int failRate = 90;
    int catastroficFailRate = 100;

    public Results Randomize()
    {
        int random = Random.Range(0, 100);

        if (random <= outstandingSucces)
            return Results.OUTSTANDING;
        else if (random <= successRate)
            return Results.SUCESS;
        else if (random <= failRate)
            return Results.FAIL;
        else
            return Results.CATASTROFIC;
    }

    public Results Execute()
    {
        return Randomize();
    }

    public ActionType GetActionType()
    {
        return type;
    }
}
