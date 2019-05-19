using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public Canvas canvas;
    public Text text;
    private GameObject lborder;
    private GameObject rborder;
    public float scrollSpeed;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
        lborder = GameObject.Find("Left");
        rborder = GameObject.Find("Right");
    }

    private void Update()
    {
        var cameraPosition = Camera.main.gameObject.transform.position;
        if (cameraPosition.x <= 180)
        {
            cameraPosition.x += scrollSpeed;
            Camera.main.gameObject.transform.position = cameraPosition;
            lborder.transform.Translate(Vector3.right * scrollSpeed);
            rborder.transform.Translate(Vector3.right * scrollSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            canvas.GetComponent<RawImage>().color = new Color(0, 0, 0, .5f);
            if (text.text == "")
                text.text = "You Win!!";
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
        SceneManager.LoadScene("Boss Fight");
    }
}

