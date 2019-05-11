using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
	GameObject player;
	Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
		rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((player.transform.position.x > 17 || player.transform.position.x < -7) && transform.position.x < 17 && transform.position.x > -7)
        {
            rb.velocity = Vector2.zero;
        }
        else if (Mathf.Abs(player.transform.position.x - transform.position.x) < 6)
        {
            Vector2 dir = player.transform.position - transform.position;
            rb.AddForce(dir.normalized * 7 * speed);
        }
        else
        {
            Vector2 dir = player.transform.position - transform.position;
            rb.AddForce(dir.normalized * 5 * speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Vector2 force = transform.position - collision.transform.position;
            force.Normalize();
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-force * (Mathf.Pow(transform.localScale.x, 3.2f)), ForceMode2D.Impulse);
        }
    }
}
