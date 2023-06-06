using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    [SerializeField] Vector3 direction;
    public float speed = 8; //public kako bismo mogli mijenjati brzinu
    public float jumpForce = 10;
    public float gravity = -20; //sila gravitacije

    public static bool gameOver;
    public GameObject gameOverPanel;
    public bool isCrouching = false;
    public float CCStandHeight = 2.0f;
    public float CCCrouchHeight = 1.9f;
    public AudioClip jumpSound;
    public AudioClip attackSound;

    public Transform groundCheck;
    public LayerMask groundLayer;

    public bool ableToMakeADoubleJump = true;

    public Animator animator;

    public Transform model;

    private float jumpHeight = 1.8f;
    private float gravityValue = -9.81f;


    CapsuleCollider playerCapsuleCollider;
    bool isGrounded;
    int playerDirection = 1;

    bool buttonHeld = false;

    public GameObject pausePanel;

    void Start()
    {
        playerCapsuleCollider = GetComponent<CapsuleCollider>();
    }

    void FixedUpdate()
    {
        if (PlayerManager.gameOver)
        {
            animator.SetTrigger("die");

            this.enabled = false;
        }


        isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer); //je li igrac na tlu

        animator.SetBool("isGrounded", isGrounded);

       // direction.y += gravity * Time.deltaTime;

        if(isGrounded && direction.y < 0)
        {
            direction.y = 0f;
        }

        direction.y += gravityValue * Time.deltaTime;
        controller.Move(motion: direction * Time.deltaTime);


        if (isGrounded)
        {
            ableToMakeADoubleJump = true;
        }

        else
        {
            
            if (model.position.y <= -20 && !isGrounded)
            {
                animator.SetTrigger("die");
                this.enabled = false;
                gameOver = true;
                gameOverPanel.SetActive(true);
                PlayerManager.currentHP = 100;
            }
        }
    
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Fireball Attack"))
            return;
    }

    public void DoubleJump()
    {
        //direction.y = jumpForce;
        direction.y += Mathf.Sqrt(f: jumpHeight * -3.0f * gravityValue);
        ableToMakeADoubleJump = false;
        animator.SetTrigger("doubleJump");
        AudioSource.PlayClipAtPoint(jumpSound, transform.position);
    }
    public void Jump()
    {
        if (isGrounded)
        {
            StandUp();
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);
            direction.y += Mathf.Sqrt(f: jumpHeight * -3.0f * gravityValue);
        }
        else if(!isGrounded && ableToMakeADoubleJump)
        {
            DoubleJump();
        }
    }

    public void Attack()
    {
        AudioSource.PlayClipAtPoint(attackSound, transform.position);
        animator.SetTrigger("fireballAttack");
        Debug.Log("Attack");
    }

    public void Crouch()
    {
        if (!isCrouching)
        {
            speed = 5;
            controller.height = CCCrouchHeight;
            playerCapsuleCollider.direction = 0;
            playerCapsuleCollider.center = new Vector3(0, -0.5f, 0);
            animator.SetTrigger("crouch");
            isCrouching = true;
            Debug.Log("Crouch");
        }
    }

    public void StandUp()
    {
        if(isCrouching)
        {
            speed = 8;
            controller.height = CCStandHeight;
            playerCapsuleCollider.direction = 1;
            playerCapsuleCollider.center = new Vector3(0, 0, 0);
            animator.SetTrigger("stand");
            isCrouching = false;
            Debug.Log("StandUp");
        }
    }

    private void CallControllerMove()
    {
        //controller.Move(direction * Time.deltaTime);
        if(buttonHeld)
        {
            direction.x = playerDirection * speed;
        }
        else
        {
            direction.x = 0;
        }
        
        if (transform.position.z != 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
    }

    public void GoLeft()
    {
        playerDirection = -1;
            model.rotation = Quaternion.LookRotation(Vector3.left);
        buttonHeld = true;
        StartCoroutine(MoveCorutine());
    }

    public void GoRight()
    {
        playerDirection = 1;
            model.rotation = Quaternion.LookRotation(Vector3.right);
        buttonHeld = true;

        StartCoroutine(MoveCorutine());
    }

    public void PauseMenu()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
    IEnumerator MoveCorutine()
    {
        animator.SetFloat("speed", Mathf.Abs(playerDirection));
        while (buttonHeld)
        {
            yield return new WaitForSeconds(0);
            
            CallControllerMove();
        }

    }

    public void StopMoving()
    {
        buttonHeld = false;
        StopCoroutine(MoveCorutine());
        animator.SetFloat("speed", 0);
        animator.SetTrigger("idle");
    }
}

