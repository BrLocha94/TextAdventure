using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public string adventureName;
    public int highScore;
    public List<Node> nodeList;

    public GameData()
    {
        adventureName = "";
        highScore = 0;
        nodeList = new List<Node>();
    }

    public void SetAdventureName(string name)
    {
        adventureName = name;
    }

    public void SetHighScore(int score)
    {
        highScore = score;
    }
    
    public void AddNode(Node node)
    {
        nodeList.Add(node);
    }

    public void RemoveNode(Node node)
    {
        nodeList.Remove(node);
    }

    public Node GetInitialNode()
    {
        if(nodeList != null)
        {
            if (nodeList.Count > 0)
                return nodeList[0];

            return null;
        }
        return null;
    }

    public void SetInitialNode(Node node)
    {
        if (nodeList != null)
        {
            if (nodeList.Count > 0)
            {
                List<Node> newList = new List<Node>();
                newList.Add(node);
                for(int i = 0; i < nodeList.Count; i++)
                {
                    if (nodeList[i] != node)
                        newList.Add(nodeList[i]);
                }
            }
            else
                nodeList.Add(node);
        }
    }
}
