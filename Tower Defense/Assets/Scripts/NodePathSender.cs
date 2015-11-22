using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class NodePathSender : MonoBehaviour
{

    [SerializeField]
    List<Node> availableNodes = new List<Node>();
    [SerializeField]
    List<Node> switchingNodes = new List<Node>();

    // Use this for initialization
    void Start()
    {




    }

    // Update is called once per frame
    void Update()
    {

    }

    public List<Node> getCurrentMapNodes
    {
        get
        {
            return availableNodes;
        }
    }
    public List<Node> getSwitchingMapNodes
    {
        get
        {
            return switchingNodes;
        }
    }


}
