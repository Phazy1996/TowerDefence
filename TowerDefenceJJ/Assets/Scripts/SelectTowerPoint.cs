using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SelectTowerPoint : MonoBehaviour
{


    public bool imSelected = false;
    GameObject towerSelected;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Ray2D newray = new Ray2D(new Vector2(ray.origin.x, ray.origin.y), new Vector2(ray.direction.x, ray.direction.y));

            RaycastHit2D hit = Physics2D.Raycast(newray.origin, newray.direction);

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.GetComponent<SelectTowerPoint>() != this.gameObject.GetComponent<SelectTowerPoint>() && !hit.collider.gameObject.GetComponent<Button>())
                {
                  

                    imSelected = false;

                }
                else
                {

                    imSelected = true;
                    if(hit.collider.gameObject.GetComponent<BuyTower>())
                    {
                        Debug.Log("Im a button");
                    }
                }
            }
            else
            {
                imSelected = false;
            }
        }

    }





    public bool GetClicked
    {
        get
        {
            return imSelected;
        }
        set
        {
            imSelected = value;
        }

    }
}
