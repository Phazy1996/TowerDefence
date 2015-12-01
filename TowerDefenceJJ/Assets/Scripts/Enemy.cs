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
    private float moveSpeed = 2f;
    private bool sideObjectiveTarget = false;
    private NodePathSender path;
    Base baseToAttack;
    private int maxNodeIndex;
    private float attackCooldown = 5f;
    private Animator animController;
    bool facingRight;
    Vector2 oldPos;
    Vector2 newPos;



    // Use this for initialization
    void Start()
    {
        applyStartingConditions();
        selectBase();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

       
        newPos = myPosition;
     
        setSpriteToMoveDir();

        maxNodeIndex = listOfNodes.Count();

        if (!isAtBase())
        {
            MoveToNode();
            if (currentNodeIndex + 1 != listOfNodes.Count)
            {
                if (checkIfAtNode())
                {
                    SelectNextNode();
                }

            }
        }
        if (currentNodeIndex == maxNodeIndex - 1 && checkIfAtNode())
        {
            attackCooldown -= Time.deltaTime * 1f;
            if (attackCooldown <= 0f)
            {
                attackBase(baseToAttack);
            }
        }
        if(health <= 0)
        {
            Die();
        }
        
    }

    private void setSpriteToMoveDir()
    {


        Vector3 theScale = transform.localScale;

       //spaghetti but w/e, unity yet to implement 2D functions -.-

        if (newPos.x > oldPos.x)
        {
            animController.SetBool("WalkingSide", true);
           animController.SetBool("WalkingDown", false);
            if (!facingRight)
            {
                facingRight = true;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
        }
        else
        {
            this.animController.SetBool("WalkingSide", false);
         
        }
        if(newPos.x < oldPos.x)
        {
            animController.SetBool("WalkingSide", true);
            animController.SetBool("WalkingDown", false);
            if (facingRight)
            {
                facingRight = false;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
        }
        else
        {
            this.animController.SetBool("WalkingSide", false);
        }
        if(newPos.y > oldPos.y || newPos.y < oldPos.y)
        {
            this.animController.SetBool("WalkingDown", true);
        }
        else
        {
            this.animController.SetBool("WalkingSide", true);
            this.animController.SetBool("WalkingDown", false);
        }
        oldPos = myPosition;
    }

    void MoveToNode()
    {
        moveToPosition = currentSelectedNode.transform.position;
        myPosition = Vector2.MoveTowards(myPosition, moveToPosition, moveSpeed * Time.deltaTime);
        this.gameObject.transform.position = myPosition;
    }

    void SelectNextNode()
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


    void switchToSideObjectivePath()
    {
        listOfNodes = path.getSwitchingMapNodes;
        //get current level's side objective path.
    }

    public void Die()
    {
        Debug.Log("ded");
        Destroy(this.gameObject);
        Destroy(this);
    }


    public float EnemyHealth
    {

        get
        {
            return health;
        }
        set
        {
            health = value;
        }

    }

    private bool checkIfAtNode()
    {
        //is in range of current node?
        Vector2 myPos = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
        float target = Vector2.Distance(myPos, moveToPosition);
        if (target == 0f && !isAtBase())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void applyStartingConditions()
    {
        animController = this.gameObject.GetComponent<Animator>();
      

        //Random chance to go for the side objective.
        if (Random.Range(0, 10) > 6)
        {
            sideObjectiveTarget = true;
        }

        

        facingRight = false;
 



        //Get node path from sender
        path = FindObjectOfType<NodePathSender>();
        if (path.getCurrentMapNodes.Count != 0)
        {
            listOfNodes = path.getCurrentMapNodes;
        }

        //Set nodeindex to starting node.
        currentNodeIndex = 0;
        currentSelectedNode = listOfNodes[currentNodeIndex];
        myPosition = listOfNodes[currentNodeIndex].gameObject.transform.position;
    }

    private void attackBase(Base target)
    {
        target = baseToAttack;
        attackCooldown = 5f;
        baseToAttack.getHealth -= 5f;
    }

    private void selectBase()
    {
        if (sideObjectiveTarget)
        {
            baseToAttack = GameObject.Find("SideBase").GetComponent<Base>();
        }
        else
        {
            baseToAttack = GameObject.Find("Base").GetComponent<Base>();
        }
    }

    private bool isAtBase()
    {
        if (currentNodeIndex == maxNodeIndex)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
