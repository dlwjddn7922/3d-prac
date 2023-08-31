using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LobbyUI : MonoBehaviour
{
    [SerializeField] private Image rankImg;
    [SerializeField] private TMP_Text highscoreText;
    [SerializeField] private TMP_Text highscoreText2;
    [SerializeField] private TMP_Text highscoreText3;
    [SerializeField] private TMP_Text lastScore;
    // Start is called before the first frame update
    void Start()
    {
        if (highscoreText != null)
            highscoreText.text = PlayerPrefs.GetInt("highscore").ToString();

        if (highscoreText2 != null)
            highscoreText2.text = PlayerPrefs.GetInt("highscore2").ToString();

        if (highscoreText3 != null)
            highscoreText3.text = PlayerPrefs.GetInt("highscore3").ToString();

        if (lastScore != null)
            lastScore.text = PlayerPrefs.GetInt("lastscore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnOK()
    {
        rankImg.gameObject.SetActive(false);
    }
    public void OnRank()
    {
        rankImg.gameObject.SetActive(true);
    }
    public void OnStart()
    {
        SceneManager.LoadScene("Ingame");
    }
    public void OnQuit()
    {
        Application.Quit();
    }
}
