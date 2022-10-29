using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnd : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    public GameObject player;
    // public CanvasGroup exitBackgroundImageCanvasGroup;

    float m_Timer;

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject == player)
        {
            EndLevel (false);
        }
    }
    public void Escape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(2);
        }
    }

    void EndLevel(bool doRestart)
    {
        m_Timer += Time.deltaTime;
        // imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if(m_Timer > fadeDuration )
        {
            if(doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
