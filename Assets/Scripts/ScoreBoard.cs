using UnityEngine;
using TMPro;


public class ScoreBoard : MonoBehaviour
{

    TMP_Text scoreText;
    public int score;


    public void Awake()
    {
        scoreText = GetComponent<TMP_Text>();
        score = 0;
        scoreText.text = score.ToString();
    }

    public void IncScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
  








}
