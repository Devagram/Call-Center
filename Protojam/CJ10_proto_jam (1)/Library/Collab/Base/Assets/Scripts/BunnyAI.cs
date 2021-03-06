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

    // Start is called before the first frame update
    void Start()
    {
    	rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        startLoc = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        bunnyTimer -= 1F * Time.deltaTime;

        if(bunnyTimer <= 0)
        {
            bunnyState = BunnyAIState.Moving;
        }

    	switch(bunnyState)
    	{
    		case BunnyAIState.Idle:
    			bunnyIdle();
    		break;

    		case BunnyAIState.Moving:
    			bunnyMove();
                //transform.position = startLoc + new Vector2(Random.Range(-2,2), Random.Range(-2, 2));
    		break;
    	}
    }

    void bunnyMove()
    {
    		Debug.Log("Bunny is moving.");
            bunnyTimer += Random.Range(2F, 2F);
            bunnyMove(bunnyTimer);
           
    }

	void bunnyIdle()
    {
    		Debug.Log("Bunny is idle.");
    }


    void defineRandPoint()
    {
    	Vector2 Point = new Vector2(Random.Range(-200,200),Random.Range(-200,200));
    }

    void bunnyMove(float waitTime)
    {
        transform.position = Vector2.Lerp(startLoc, startLoc + new Vector2(Random.Range(-10, 10), Random.Range(-10, 10)), 1F * Time.deltaTime);
        bunnyState = BunnyAIState.Idle;
    }
}
