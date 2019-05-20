using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public Canvas canvas;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            canvas.GetComponent<RawImage>().color = new Color(0, 0, 0, .5f);
            if (text.text == "")
                text.text = "You Win!!";
            StartCoroutine(GoToBossFight());
        }
    }

    IEnumerator GoToBossFight()
    {
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
        SceneManager.LoadScene("Boss Fight");
    }
}

