using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour
{


    private Vector2 pos;
    [SerializeField]
    bool switchingNode = false;


    // Use this for initialization
    void Start()
    {
        pos = new Vector2(this.transform.position.x, this.transform.position.y);
    }

    public Vector2 GetNodePosition
    {
        get
        {
            return pos;
        }
    }

    public bool isSwitchingNode
    {

        get
        {
            return switchingNode;
        }
    }
}
