using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BunnyAI : MonoBehaviour
{
    public enum BunnyAIState
    {
        Idle,
        Moving
    }

    public BunnyAIState bunnyState;
    public bool bunnyMoving;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;
    private Vector2 startLoc;
    private Vector2 moveVector;
    public float bunnyTimer = 2F;
    public float moveSpeed = 2F;

    public float idleTimer = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        startLoc = transform.position;
    }

    // Update is called once per frame
    void Update()
    {



        switch (bunnyState)
        {
            case BunnyAIState.Idle:
                bunnyIdle();
                break;

            case BunnyAIState.Moving:
                bunnyMove();
                break;
        }
    }


    private void FixedUpdate()
    {
        rb.velocity = moveVector * moveSpeed;
    }
    void bunnyMove()
    {
        bunnyTimer -= Time.deltaTime;
        animator.SetFloat("WalkHor", moveVector.x);
        animator.SetFloat("WalkVer", moveVector.y);
        if (bunnyTimer <= 0)
        {
            bunnyState = BunnyAIState.Idle;
            idleTimer = Random.Range(2f, 5f);
            moveVector = Vector2.zero;
            animator.SetBool("Walking", false);
        }

    }

    void bunnyIdle()
    {
        idleTimer -= Time.deltaTime;
        if (idleTimer <= 0)
        {
            bunnyState = BunnyAIState.Moving;
            bunnyTimer = Random.Range(2f, 5f);
            moveVector = GetRandomPos();
            animator.SetBool("Walking", true);
        }
    }

    public Vector2 GetRandomPos()
    {
        Vector2 offset = new Vector2(Random.Range(-2, 2), Random.Range(-2, 2));
        return Vector2.ClampMagnitude((startLoc + offset) - (Vector2)transform.position,1);
    }
}
