using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float oscillationSpeed, oscillationDistance, sizeIncrease;
    public bool oscillateX, oscillateY;
    private float startPositionX, startPositionY;

    private void Start()
    {
        startPositionX = transform.position.x;
        startPositionY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (oscillateX)
            transform.position = new Vector2(startPositionX + (Mathf.Sin(oscillationSpeed * Time.time) * oscillationDistance), transform.position.y);
        else if (oscillateY)
            transform.position = new Vector2(transform.position.x, startPositionY + (Mathf.Sin(oscillationSpeed * Time.time) * oscillationDistance));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
