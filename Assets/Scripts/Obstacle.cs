using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    public Canvas canvas;
    public Text text;
    public float oscillationSpeed, oscillationDistance;
    public bool oscillateX, oscillateY;
    private float startPositionX, startPositionY;

    // Start is called before the first frame update
    void Start()
    {
        startPositionX = transform.position.x;
        startPositionY = transform.position.y;
        text.text = "";
    }

    private void Update()
    {
        if (oscillateX)
            transform.position = new Vector2(startPositionX + (Mathf.Sin(oscillationSpeed * Time.time) * oscillationDistance), transform.position.y);
        else if (oscillateY)
            transform.position = new Vector2(transform.position.x, startPositionY + (Mathf.Sin(oscillationSpeed * Time.time) * oscillationDistance));


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            canvas.GetComponent<RawImage>().color = new Color(0, 0, 0, .5f);
            if (text.text == "")
                text.text = "You Lose!!";
            StartCoroutine(Wait());
        }
    }

    private void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(3);
        Restart();
    }
}
