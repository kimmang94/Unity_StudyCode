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
    void Start()
    {
        Invoke("InactiveImage", 1.0f);
        panel.SetActive(false);
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
        }
        else if (PlayerController.gameState == "playing")
        { 
            
        }
    }

    void InactiveImage()
    {
        mainImage.SetActive(false);
    }
}
