using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    Node [] PathNode;
    public GameObject Player;

    public float MoveSpeed;
    int currentNode;
    float Timer;
    static Vector3 CurrentPositionHolder;
    bool Move;
    void Start()
    {
        PathNode = GetComponentsInChildren<Node> ();
        CheckNode();


    }

    void CheckNode()
    {
        if(currentNode < PathNode.Length -1)
        CurrentPositionHolder = PathNode[currentNode].transform.position;
        Timer = 0;
    }

    void DrawLine()
    {
        for(int i = 0; i < PathNode.Length; i++)
        {
            if (i < PathNode.Length)
            {
                //Debug.DrawLine(PathNode[i].transform.position, PathNode[i + 1].transform.position, Color.green);
            }
                
        }
    }

    void Update()
    {
        DrawLine();
        Timer += Time.deltaTime * MoveSpeed;
        if (Input.GetKeyDown("space"))
        {
            Move = true;
        }
        if (Player.transform.position != CurrentPositionHolder)
        {
            Player.transform.position = Vector3.Lerp(Player.transform.position, CurrentPositionHolder, Timer);
        }
        else
        {
            if(currentNode < PathNode.Length - 1)
            {
                currentNode++;
            }
            
            CheckNode();
        }
    }
}
