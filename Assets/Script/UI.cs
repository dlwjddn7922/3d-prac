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
    [SerializeField] TMP_Text hightScoretxt;
    [SerializeField] TMP_Text lastScoretxt;
    [SerializeField] Image dieImage;
    [SerializeField] Image coindieImage;
    [SerializeField] PlayerController player;
 
    private int startinghighscore;
    private int startinghighscore2;
    private int startinghighscore3;

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
        startinghighscore2 = PlayerPrefs.GetInt("highscore2");
        startinghighscore3 = PlayerPrefs.GetInt("highscore3");  
        Score = 0;
        Coin = 500;
    }

    // Update is called once per frame
    void Update()
    {
        savesocre();
        if (player.playerdie == true)
        {
            coindieImage.gameObject.SetActive(true);
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
        dieImage.gameObject.SetActive(true);
    }
    public void UpdateHighScore()
    {
        if (Score > startinghighscore)
        {
            PlayerPrefs.SetInt("highscore3", startinghighscore2);
            PlayerPrefs.SetInt("highscore2", startinghighscore);
            PlayerPrefs.SetInt("highscore", Score);

        }
        else if (Score > startinghighscore2)
        {
            PlayerPrefs.SetInt("highscore3", startinghighscore2);
            PlayerPrefs.SetInt("highscore2", Score);
        }
        else if (Score > startinghighscore3)
        {
            PlayerPrefs.SetInt("highscore3", Score);
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
    public void OnLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
    public void Onrevive()
    {
        coindieImage.gameObject.SetActive(false);
        player.gameObject.SetActive(true);
        player.playerdie = false;
        Coin -= 50;
        player.OnDamaged();
    }
}
