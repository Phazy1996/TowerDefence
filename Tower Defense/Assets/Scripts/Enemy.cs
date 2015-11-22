using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Enemy : MonoBehaviour
{



    private List<Node> listOfNodes;
    private Vector2 moveToPosition;
    private Vector2 myPosition;
    private Vector2 distanceToNode;
    private int currentNodeIndex;
    private Node currentSelectedNode;
    private float health = 5f;
    [SerializeField]
    private float moveSpeed = 5f;
    private bool sideObjectiveTarget = false;
    private bool hasReachedNode = false;
    private NodePathSender path;
    GameObject baseToAttack;

    // Use this for initialization
    void Start()
    {
        applyStartingConditions();
        selectBase();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isAtBase)
        {
            MoveToNode();
        }
        if(isAtBase)
        {
            attackBase(baseToAttack);
        }
    }

    void MoveToNode()
    {
        moveToPosition = currentSelectedNode.transform.position;
        myPosition = Vector2.MoveTowards(myPosition, moveToPosition, moveSpeed * Time.deltaTime);
        this.gameObject.transform.position = myPosition;

        if (!hasReachedNode)
        {
            checkIfAtNode();
        }
    }

    void SelectNextNode()
    {
        if (currentNodeIndex + 1 != listOfNodes.Count)
        {
            if (sideObjectiveTarget)
            {
                if (currentSelectedNode.isSwitchingNode == true)
                {
                    switchToSideObjectivePath();
                    currentNodeIndex = -1;
                }
            }
            currentNodeIndex++;
            currentSelectedNode = listOfNodes[currentNodeIndex];
        }
    }

    private void switchToSideObjectivePath()
    {
        listOfNodes = path.getSwitchingMapNodes;
        //get current level's side objective path.
    }

    void Die()
    {
        Destroy(this.gameObject);
        Destroy(this);
    }


    public float EnemyHealth
    {

        get
        {
            return this.health;
        }
        set
        {
            this.health = value;
        }

    }

    bool isAtBase
    {
        get
        {
            if (currentNodeIndex != listOfNodes.Count)
            {
                return false;
            }
            else
            {
                Debug.Log("At base!");
                return true;
            }
        }
    }
    private void checkIfAtNode()
    {
        //is in range of current node?
        Vector2 myPos = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
        float target = Vector2.Distance(myPos, moveToPosition);
        if (target < 0.2f)
        {
            SelectNextNode();
            hasReachedNode = false;
            //select next node, make sure he knows he hasnt reached the next.
        }
    }

    private void applyStartingConditions()
    {
        //Random chance to go for the side objective.
        if (Random.Range(0, 10) > 6)
        {
            sideObjectiveTarget = true;
        }

        //Get node path from sender
        path = FindObjectOfType<NodePathSender>();
        if (path.getCurrentMapNodes.Count != 0)
        {
            listOfNodes = path.getCurrentMapNodes;
        }

        //Set nodeindex to starting node.
        currentNodeIndex = 0;
        currentSelectedNode = listOfNodes[currentNodeIndex]; ;
    }

    private void attackBase(GameObject Target)
    {
        Debug.Log("Attacking " + Target);
    }

    private void selectBase()
    {
        if (sideObjectiveTarget)
        {
            baseToAttack = GameObject.Find("SideBase");
        }
        else
        {
            baseToAttack = GameObject.Find("Base");
        }
    }
}
