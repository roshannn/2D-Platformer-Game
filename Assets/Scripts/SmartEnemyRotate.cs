using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartEnemyRotate : MonoBehaviour
{
    EnemyController enemyController;
    private void Start()
    {
        enemyController = this.GetComponentInParent<EnemyController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Debug.Log("ground detected by enemy");
        }
        if (collision.gameObject.tag == "wall")
        {
            enemyController.MovementFlip();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            enemyController.MovementFlip();
        }
    }   
}

