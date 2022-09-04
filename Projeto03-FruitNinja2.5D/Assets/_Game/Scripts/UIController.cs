using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public TMP_Text txtScore, txtHighScore;
    public Image[] imgLives;
    public Button btnPause, btnResume, btnMainMenu, btnClosePauseMenu, btnSounds;
    public GameObject panelGame, panelPause, panelGameOver;
    private GameController gameController;
    private GameData gameData;
    public Sprite imgSoundOn, imgSoundOff;  
    private AudioController audioController;
    // Start is called before the first frame update
    void Start()
    {
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
        gameController = FindObjectOfType<GameController>();
        audioController = FindObjectOfType<AudioController>();
        gameData = FindObjectOfType<GameData>();
        txtHighScore.text = "Highscore: " + gameData.GetScore().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPauseGame()
    {
        panelGame.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ButtonClosePanelPause()
    {
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
        Time.timeScale = 1f;
        gameController.SoundsData();
    }
    public void ShowPanelGameOver()
    {
        panelGameOver.gameObject.SetActive(true);
        panelGame.SetActive(false); //desativa o painel de game
        gameController.GameOver();
        txtHighScore.text = "Highscore: " + gameData.GetScore().ToString();
    }

    public IEnumerator ShowBombPanelGameOver()
    {
        gameController.GameOver();
        panelGame.SetActive(false); //desativa o painel de game
        yield return new WaitForSeconds(3f);
        panelGameOver.gameObject.SetActive(true);
        txtHighScore.text = "Highscore: " + gameData.GetScore().ToString();
    }

    public void ButtonRestartGame()
    {
        panelGame.gameObject.SetActive(true);
        panelGameOver.SetActive(false);
        gameController.RestartGame();

        for(int i = 0; i < imgLives.Length; i++){
            imgLives[i].color = gameController.uIWhiteColor;
        }
    }

    public void ButtonSounds()
    {
        if (gameController.soundOnOff)
        {
            gameController.soundOnOff = false;
            gameData.SaveSounds(0);
            btnSounds.gameObject.GetComponent<Image>().sprite = imgSoundOff;
        }
        else
        {
            gameController.soundOnOff = true;
            gameData.SaveSounds(1);
            btnSounds.gameObject.GetComponent<Image>().sprite = imgSoundOn;
        }

        audioController.EnableAndDisableAudio();
    }
}
