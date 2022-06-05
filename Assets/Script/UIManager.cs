using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameManager GameManager;
    public CanvasGroup gameOverPanel;
    public CanvasGroup finishPanel;
    private void Start()
    {
        gameOverPanel.gameObject.SetActive(false);
        finishPanel.gameObject.SetActive(false);       
    }
    void EnableGamever()
    {

        gameOverPanel.gameObject.SetActive(true);

    }
    void EnableFinish()
    {
        finishPanel.gameObject.SetActive(true);
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   public void NextLevel()
    {
        finishPanel.gameObject.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Next Level Invalid";
    }
    private void Update()
    {
        if (GameManager.isGameOver)
        {
            EnableGamever();
        }
       else if (GameManager.finishedScene)

        {
            EnableFinish();
        }
    }
}
