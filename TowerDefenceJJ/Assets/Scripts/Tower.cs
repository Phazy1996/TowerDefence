using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using System.Linq;

public class Tower : MonoBehaviour
{

    [SerializeField]
    public enum towerType
    {
        priest,
        archer
    }



    [SerializeField]
    Sprite[] archerTowerSprites;
    [SerializeField]
    Sprite[] priestTowerSprites;
    SpriteRenderer spriteRenderer;
    [SerializeField]
    float fireRate = 2f;
    [SerializeField]
    float range = 0.5f;
    float damage = 5f;
    
    CircleCollider2D myColl;
    int towerLevel = 0;

    // Use this for initialization
    void Start()
    {
        
        myColl = this.gameObject.GetComponent<CircleCollider2D>();
        myColl.radius = range;
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
       


    }

    // Update is called once per frame
    void Update()
    {
     
        fireRate -= Time.deltaTime;
        myColl.radius = range;
        


        if (fireRate <= 0)
        {
            
            if (getTargetsInRange.Length > 1)
            {
               shootAtEnemy();
               fireRate = 2f;
            }
            else
            {
                fireRate = 1f;
            }
        }
    }

    private void shootAtEnemy()
    {
        if (getTargetsInRange.Length != 0)
        {
            Enemy randomTargetInRange = getTargetsInRange[Random.Range(0, getTargetsInRange.Length)].GetComponent<Enemy>();
            if (randomTargetInRange != null)
            {
                randomTargetInRange.EnemyHealth -= damage;
            }
        }
    }

    private Collider2D[] getTargetsInRange
    {
        get
        {
            Collider2D[] objects = Physics2D.OverlapCircleAll(this.gameObject.transform.position, range * Mathf.Max(gameObject.transform.localScale.x, gameObject.transform.localScale.y));

            return objects;
        }
    }
    
    public void switchSpriteToTowerType(towerType t)
    {
        

        switch(t)
        {
            case towerType.archer:
                spriteRenderer.sprite = archerTowerSprites[towerLevel];
                break;
            case towerType.priest:
                spriteRenderer.sprite = priestTowerSprites[towerLevel];
                break;
        }


    }

    public void upgradeTower()
    {
        if (towerLevel != 3)
            
        {
            Debug.Log("upgradin");
            towerLevel++;
            fireRate -= 0.1f;
            damage += 3f;
            range += 0.5f;
        }
    }

}
