using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text bestscoreText;

    private float score;
    private bool gameover;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        gameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameover)
        {
            score += Time.deltaTime;
            timeText.text = Mathf.Floor(score * 10f) / 10f + " sec";
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public bool isGameover()
    {
        if (gameover) return true;
        else return false;
    }

    public void Gameover()
    {
        gameover = true;
        gameoverText.SetActive(true);

        float bestScore = PlayerPrefs.GetFloat("BestScore");

        if(score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetFloat("BestScore", bestScore);
        }
        bestscoreText.text = "Best Score : " + Mathf.Floor(bestScore * 10f) / 10f;
    }
}
