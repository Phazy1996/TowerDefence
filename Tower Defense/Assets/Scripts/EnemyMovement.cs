using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemyMovement : MonoBehaviour {


    
    private List<Node> listOfNodes;
    private Vector2 moveToPosition;
    private Vector2 myPosition;
    private int currentNodeIndex;
    private Node currentSelectedNode;

	// Use this for initialization
	void Start () {

        currentNodeIndex = 0;
        listOfNodes = FindObjectOfType<NodePathSender>().getCurrentMapNodes;
        currentSelectedNode = listOfNodes[currentNodeIndex];
        myPosition = this.gameObject.transform.position;
    }

	
	
	// Update is called once per frame
	void Update () {

       
        MoveToNode();
        this.gameObject.transform.position = myPosition;

	}

    void MoveToNode()
    {

       
            Debug.Log("Moving to " + currentSelectedNode.gameObject.name + currentSelectedNode.transform.position);
            moveToPosition = currentSelectedNode.transform.position;
            myPosition = Vector2.MoveTowards(this.gameObject.transform.position, moveToPosition, 2f);

           if (myPosition.magnitude + 50f == moveToPosition.magnitude + 50f)
            {
                SelectNextNode();

            }
        
    }

    void SelectNextNode()

    {
        if (currentNodeIndex != listOfNodes.Count-1)
        {
            currentNodeIndex++;
            currentSelectedNode = listOfNodes[currentNodeIndex];
        }
       

    }

}
