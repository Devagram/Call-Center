using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovment : MonoBehaviour
{


    [SerializeField] private float  moveSpeed=4;
    [SerializeField] private AudioClip[] feetSFX;
    private AudioSource audioSC;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;
    private Vector2 moveVector;
    public float sfxTimer = 0.1f;
    [SerializeField] public float sfx_Time = 0.1f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        audioSC = GetComponent<AudioSource>();

    }


    void Update()
    {

        moveVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (moveVector.magnitude >= Mathf.Epsilon)
        {
            animator.SetBool("Walking", true);
            animator.SetFloat("WalkHor", moveVector.x);
            animator.SetFloat("WalkVer", moveVector.y);
            sfxTimer -= Time.deltaTime;
			if (sfxTimer <= 0)
			{
                audioSC.pitch = Random.Range(0.9f, 1.01f);
                audioSC.clip = feetSFX[Random.Range(0, feetSFX.Length)];
                audioSC.Play();
                sfxTimer = sfx_Time;
            }


        }
		else
		{
            animator.SetBool("Walking", false);
        }


        if (moveVector.magnitude > 0)
        {
            moveVector = Vector2.ClampMagnitude(moveVector, 1);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVector * moveSpeed;
    }

}
