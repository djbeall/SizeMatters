﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    private bool jumping;
    private bool grounded;
    private bool canMove;
    private float jumpTime;
	public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpTime = .1f;
        grounded = false;
        canMove = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.mass = transform.localScale.x;
		if(Input.GetKeyDown("space") && grounded) {
            jumping = true;
            StartCoroutine(JumpRoutine());
        }
        float moveHorizontal = Input.GetAxis("Horizontal");

        if(canMove)
            rb.AddForce(Vector2.right * moveHorizontal * speed * (transform.localScale.x));
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("1");
        if (collision.gameObject.tag == "Terrain")
            grounded = true;
        if (collision.gameObject.name == "Boss")
        {
            //Debug.Log("Here");
            StartCoroutine(MoveWait());
            Vector2 force = transform.position - collision.transform.position;
            force.Normalize();
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-force * (Mathf.Pow(transform.localScale.x, 2)), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Terrain")
            grounded = false;
    }

    IEnumerator JumpRoutine()
    {
        float timer = 0;

        while (Input.GetKey("space") && timer < jumpTime)
        {
            float proportionCompleted = timer / jumpTime;
            Vector2 thisFrameJumpVector = Vector2.Lerp(Vector2.up * 115, Vector2.zero, proportionCompleted);
            rb.AddForce(thisFrameJumpVector);
            timer += Time.deltaTime;
            yield return null;
        }

        jumping = false;
    }

    IEnumerator MoveWait()
    {
        canMove = false;
        yield return new WaitForSeconds(.5f);
        canMove = true;
    }

}
