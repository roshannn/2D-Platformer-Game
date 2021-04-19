using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{   // state variables
    
    bool isGrounded;
    
    
    [Header("Health...")]
    
    public int health ;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    
    //Constant Strings
    
    const string HORIZONTAL = "Horizontal";
    const string JUMP = "Jump";
    const string GROUNDED = "isGrounded";
    
    [Header("Score...")]
    
    [SerializeField] int scorePerKey;
    public ScoreController scoreController;
   
    [Header("Movement...")]
    
    [Range(0,10)][SerializeField] float moveSpeed;
    [SerializeField] float jumpForce;
    
    //cached references
    
    Animator animator;
    JumpCollider jumpCollider;
    Rigidbody2D rb2d;
    BoxCollider2D boxCollider;
    public SceneLoader sceneLoader;
    private void Start()
    {
        animator = this.GetComponent<Animator>();
        jumpCollider = this.GetComponentInChildren<JumpCollider>();
        rb2d = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw(HORIZONTAL);
        float crouch = Input.GetAxisRaw("Crouch");
        float jump = Input.GetAxisRaw(JUMP);
        SetGrounded();
        JumpAnimation(jump);
        MoveAnimation(horizontal);
        CrouchAnimation(crouch);
        PlayerMovement(horizontal, crouch, jump);
        CheckHealth();
        isGrounded = jumpCollider.GrounChecker();
    }

    private void CheckHealth()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    private void SetGrounded()
    {
        animator.SetBool(GROUNDED, isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.GetComponent<EnemyController>() != null && health>0)
        {
            DamagePlayer();
        }
    }

    private void DamagePlayer()
    {
        health--;
        if (health == 0)
        {
            DeathAnimation();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Health: " + health);
    }
    
    private void DeathAnimation()
    {
        animator.SetBool("Dead", true);
        
    }
    public void PickUpKey()
    {
        scoreController.IncreaseScore(scorePerKey);
    }

    private void ReloadScene()
    {
        sceneLoader.ReloadScene();
    }
    
    

    private void PlayerMovement(float horizontal,float crouch,float jump)
    {
        if (!animator.GetBool("Dead"))
        {
            Vector3 playerPos = transform.position;
            if (crouch > 0)
            {
                playerPos.x += horizontal * moveSpeed * Time.deltaTime * 0.2f;
            }
            else
            {
                playerPos.x += horizontal * moveSpeed * Time.deltaTime;
            }
            transform.position = playerPos;

            if (jump > 0 && isGrounded)
            {
                rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
        

    }

    private void CrouchAnimation(float crouch)
    {
        
        if (crouch > 0)
        {
            animator.SetBool("isCrouch", true);
            boxCollider.offset = new Vector2(-0.17f, 0.60f);
            boxCollider.size = new Vector2(0.88f, 1.38f);
        }
        else
        {
            animator.SetBool("isCrouch", false);
            boxCollider.offset = new Vector2(0.024f, 1.01f);
            boxCollider.size = new Vector2(0.62f, 2.07f);
        }
    }

    private void MoveAnimation(float horizontal)
    {

        if (!animator.GetBool("Dead"))
        {
            float absHorizontal = Mathf.Abs(horizontal);
            animator.SetFloat("Speed", absHorizontal);
            Vector3 scale = transform.localScale;
            if (horizontal > 0)
            {
                scale.x = absHorizontal;
            }
            else if (horizontal < 0)
            {
                scale.x = -1f * absHorizontal;
            }
            transform.localScale = scale;
        }
        
    }

    private void JumpAnimation(float jump)
    {
        
        if (jump > 0)
        {
            animator.SetBool("Jump", true);
        }
        else 
        {
            animator.SetBool("Jump", false);
        }
    }
}
