using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCanvas;
    [SerializeField] Canvas scoreBoard;
    void Start()
    {
        gameOverCanvas.enabled = false;
        scoreBoard.enabled = true;
        
        
    }

    public void handleDeth()
    {
        gameOverCanvas.enabled = true;
        TMP_Text finalScore = GameObject.Find("Game Over Text").GetComponent<TMP_Text>();
        finalScore.text += "\n YOUR SCORE IS: \n"+ GameObject.Find("Score Board").GetComponent<TMP_Text>().text;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        scoreBoard.enabled = false;
    }


}
