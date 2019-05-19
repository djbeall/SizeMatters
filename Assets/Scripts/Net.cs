using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Net : MonoBehaviour
{
    public Canvas canvas;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                canvas.GetComponent<RawImage>().color = new Color(0, 0, 0, .5f);
                text.text = "Paused";
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                canvas.GetComponent<RawImage>().color = new Color(0, 0, 0, 0);
                text.text = "";
            }
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            Restart();
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            canvas.GetComponent<RawImage>().color = new Color(0, 0, 0, .5f);
            if(text.text == "")
                text.text = "You Lose!!";
            StartCoroutine(Wait());
        }
        if (collision.gameObject.name == "Boss")
        {
            canvas.GetComponent<RawImage>().color = new Color(0, 0, 0, .5f);
            if (text.text == "")
                text.text = "You Win!!";
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
