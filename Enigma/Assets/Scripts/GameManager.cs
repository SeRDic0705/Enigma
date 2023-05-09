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
    public AudioClip ohoh;
    public AudioClip explosion;

    private AudioSource audio;
    private float score;
    //private bool isGameover;
    public bool isGameover;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        score = 0;
        isGameover = false;

        audio.clip = ohoh;
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover)
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

    public void Gameover()
    {
        audio.clip = explosion;
        audio.Play();

        isGameover = true;
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
