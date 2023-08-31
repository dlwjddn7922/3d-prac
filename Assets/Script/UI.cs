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
    [SerializeField] TMP_Text coinTxt;
    [SerializeField] Image dieImg;
    [SerializeField] Image coindieImg;
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
    private int coin;
    public int Coin
    {
        get
        {
            return coin;
        }
        set
        {
            coin = value;
            coinTxt.text = $"{coin}";
        }
    }
    void Start()
    {
        startinghighscore = PlayerPrefs.GetInt("highscore");
        Score = 0;
        Coin = 50;
    }

    // Update is called once per frame
    void Update()
    {
        savesocre();
        if (player.playerdie == true)
        {
            coindieImg.gameObject.SetActive(true);
        }
        if (player == null)
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
    public void OnQuit()
    {
        Application.Quit();
    }
    public void Onrevive()
    {
        player.gameObject.SetActive(true);
        coindieImg.gameObject.SetActive(false);
        player.playerdie = false;
        Coin -= 50;
        player.OnDamaged();
    }
}
