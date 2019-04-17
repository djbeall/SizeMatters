using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

	public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if(Input.GetKeyDown("space")) {
			rb.AddForce(Vector2.up * 250 * (transform.localScale.x * 2));
		}
        float moveHorizontal = Input.GetAxis("Horizontal");

        rb.AddForce(Vector2.right * moveHorizontal * speed * (transform.localScale.x));
    }
}
