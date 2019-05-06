using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    private bool jumping;
    private float jumpTime;
	public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpTime = .13f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.mass = transform.localScale.x;
		if(Input.GetKeyDown("space")) {
            jumping = true;
            StartCoroutine(JumpRoutine());
            //rb.AddForce(Vector2.up * 250 * (transform.localScale.x * 2));
        }
        float moveHorizontal = Input.GetAxis("Horizontal");

        rb.AddForce(Vector2.right * moveHorizontal * speed * (transform.localScale.x));
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("1");
        if (collision.gameObject.name == "Boss")
        {
            //Debug.Log("Here");
            float magnitude = 5;
            Vector2 force = transform.position - collision.transform.position;
            force.Normalize();
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-force * (transform.localScale.x * 5), ForceMode2D.Impulse);
        }
    }

    IEnumerator JumpRoutine()
    {
        rb.velocity = Vector2.zero;
        float timer = 0;

        while (Input.GetKey("space") && timer < jumpTime)
        {
            //Calculate how far through the jump we are as a percentage
            //apply the full jump force on the first frame, then apply less force
            //each consecutive frame
            float proportionCompleted = timer / jumpTime;
            Vector2 thisFrameJumpVector = Vector2.Lerp(Vector2.up * 100, Vector2.zero, proportionCompleted);
            rb.AddForce(thisFrameJumpVector);
            timer += Time.deltaTime;
            yield return null;
        }

        jumping = false;
    }

}
