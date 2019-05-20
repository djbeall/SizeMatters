using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boundaries : MonoBehaviour
{
    public Canvas canvas;
    public Text text;
    public float scrollSpeed;
    private GameObject lborder;

    // Start is called before the first frame update
    void Start()
    {
        lborder = GameObject.Find("LeftBorder");
    }

    // Update is called once per frame
    void Update()
    {
        var cameraPosition = Camera.main.gameObject.transform.position;
        cameraPosition.x += scrollSpeed;
        Camera.main.gameObject.transform.position = cameraPosition;
        lborder.transform.Translate(Vector3.right * scrollSpeed);

    }

    private void OnTriggerEnter2D(Collider2D collision)
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
