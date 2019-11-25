using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField]
    private Node frontPath;
    [SerializeField]
    private Node backPath;
    [SerializeField]
    private Node leftPath;
    [SerializeField]
    private Node rightPath;

    private string description;

    private List<Interacteble> possibleInteractions;
    private List<Action> possibleActions;

    void Start()
    {
        if (possibleInteractions == null)
            possibleInteractions = new List<Interacteble>();

        if (possibleActions == null)
            possibleActions = new List<Action>();
    }
}
