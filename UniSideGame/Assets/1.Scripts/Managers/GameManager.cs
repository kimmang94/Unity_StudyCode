using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject mainImage;
    public Sprite gameOverSpr;
    public Sprite gameClearSpr;
    public GameObject panel;
    public GameObject restartButton;
    public GameObject nextButton;

    Image titleImage;

    public GameObject timeBar;
    public GameObject timeText;
    TimeController timeCnt;

    public GameObject scoreText;
    public static int totalScore;
    public int stageScore = 0;
    void Start()
    {
        Invoke("InactiveImage", 1.0f);
        panel.SetActive(false);

        timeCnt = GetComponent<TimeController>();
        if (timeCnt != null)
        {
            if (timeCnt.gameTime == 0.0f)
            {
                timeBar.SetActive(false);
            }
        }
        UpdateScore();

    }

   
    void Update()
    {
        if (PlayerController.gameState == "gameclear")
        {
            Debug.Log("게임클리어");
            mainImage.GetComponent<Image>().sprite = gameClearSpr;
            mainImage.SetActive(true);
            panel.SetActive(true);
            Button bt = restartButton.GetComponent<Button>();
            bt.interactable = false;
            PlayerController.gameState = "gameend";

            if (timeCnt != null)
            {
                timeCnt.isTimeOver = true;
                int time = (int)timeCnt.displayTime;
                totalScore += time * 10;
            }

            totalScore += stageScore;
            stageScore = 0;
            UpdateScore();
        }
        else if (PlayerController.gameState == "gameover")
        {
            Debug.Log("게임오버");
            mainImage.GetComponent<Image>().sprite = gameOverSpr;
            mainImage.SetActive(true);
            panel.SetActive(true);
            Button bt = nextButton.GetComponent<Button>();
            bt.interactable = false;
 
            PlayerController.gameState = "gameend";

            if (timeCnt != null)
            {
                timeCnt.isTimeOver = true;
            }
        }
        else if (PlayerController.gameState == "playing")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerController playerCnt = player.GetComponent<PlayerController>();

            if (timeCnt != null)
            {
                if (timeCnt.gameTime > 0.0f)
                {
                    int time = (int)timeCnt.displayTime;
                    timeText.GetComponent<Text>().text = time.ToString();

                    if (time == 0)
                    {
                        playerCnt.GameStop();
                    }

                }
                if (playerCnt.score != 0)
                {
                    stageScore += playerCnt.score;
                    playerCnt.score = 0;
                    UpdateScore();

                }
            }
        }
    }

    void InactiveImage()
    {
        mainImage.SetActive(false);
    }

    void UpdateScore()
    {
        int score = stageScore + totalScore;
        scoreText.GetComponent<Text>().text = score.ToString();
    }
}
