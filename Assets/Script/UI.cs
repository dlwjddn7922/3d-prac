using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : Singleton<UI>
{
    // Start is called before the first frame update
    [SerializeField] TMP_Text scoreTxt;
    [SerializeField] Image dieImg;
    [SerializeField] TMP_Text hightScoretxt;
    [SerializeField] TMP_Text lastScoretxt;
    [SerializeField] PlayerController player;
    int currentScore = 0;
 
    private int startinghighscore;

    private int score;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            scoreTxt.text = $"{score}";
        }
    }
    void Start()
    {
        startinghighscore = PlayerPrefs.GetInt("highscore");
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        savesocre();
        if(player == null)
        {
            Gameover();
        }
    }
    public void Gameover()
    {
        if (player == null)
        { UpdateHighScore(); }
        dieImg.gameObject.SetActive(true);
    }
    public void UpdateHighScore()
    {
        if (Score > startinghighscore)
        {
            PlayerPrefs.SetInt("highscore", Score);
        }
        PlayerPrefs.SetInt("lastscore", Score);
    }
    void savesocre()
    {
        if (hightScoretxt != null)
            hightScoretxt.text = PlayerPrefs.GetInt("highscore").ToString();
        if (lastScoretxt != null)
            lastScoretxt.text = PlayerPrefs.GetInt("lastscore").ToString();
    }
    public void OnRestart()
    {              
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
