using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Range(0, 10)] public float moveSpeed;
    public Animator animator;
    public GameObject SmartCollider;
    
    private void Start()
    {
        CheckIfSmart();
    }

    private void CheckIfSmart()
    {
        if(gameObject.tag == "SmartEnemy")
        {
            SmartCollider.SetActive(true);
        }
        else
        {
            SmartCollider.SetActive(false);
        }
    }

    
    public void MovementFlip()
    {
        Vector3 scale = transform.localScale;
        if (scale.x < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if (scale.x > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {   
        Vector3 enemyPos = gameObject.transform.position;
        
        if(transform.localScale.x > 0.1)
        {
            enemyPos.x += moveSpeed * Time.deltaTime;

        }
        else if(transform.localScale.x < 0.1)
        {
            enemyPos.x -= moveSpeed * Time.deltaTime;
        }

        //else if(transform.rotation.y == 180)
        //{
        //  enemyPos.x -=  moveSpeed * Time.deltaTime;
        //}
        transform.position = enemyPos;
    }
}
