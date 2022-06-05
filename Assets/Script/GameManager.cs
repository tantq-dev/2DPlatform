using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;
   public  bool finishedScene;
    public GameObject enemyHolder;
    public ActionController controller;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameLoop();
    }
    void GameLoop()
    {
        GameOver();
        FinishScene();
    }
    void GameOver()
    {
        if (controller.currentHealth ==0)
        {
            isGameOver = true;
            Debug.Log("Game over");
        }
    }
    void FinishScene()
    {
        if (enemyHolder.transform.childCount == 0)
        {
            finishedScene = true;
            Debug.Log("FinishScene");
        }
    }
    
}
