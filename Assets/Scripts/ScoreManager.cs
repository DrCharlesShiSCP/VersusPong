using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int player1Score = 0;
    public int player2Score = 0;
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    public GameObject Gameover1;
    public GameObject Gameover2;
    public string tagToDestroy;
    public GameObject GameAudio;
    public GameObject EndAudio;


    public void AddScore(bool isPlayerTwo, int points)
    {
        if (isPlayerTwo)
        {
            player2Score += points;
            player2ScoreText.text = "Score: " + player2Score;
        }
        else
        {
            player1Score += points;
            player1ScoreText.text = "Score: " + player1Score;
        }
    }
    private void Start()
    {
        player2ScoreText.text = "Score: " + player2Score;
        player1ScoreText.text = "Score: " + player1Score;

    }

    public void finish()
    {
        if (player1Score > player2Score)
        {
            Gameover2.SetActive(true);
            GameAudio.SetActive(false);
            EndAudio.SetActive(true);
        }
        if (player1Score < player2Score)
        {
            Gameover1.SetActive(true);
            GameAudio.SetActive(false);
            EndAudio.SetActive(true);
        }

        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tagToDestroy);

        foreach (GameObject obj in objectsWithTag)
        {
            Destroy(obj);
        }
    }
}
