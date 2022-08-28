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
    // Start is called before the first frame update
    void Start()
    {
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
        gameController = FindObjectOfType<GameController>();
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
    }
    public void ShowPanelGameOver()
    {
        panelGameOver.gameObject.SetActive(true);
        panelGame.SetActive(false); //desativa o painel de game
        gameController.GameOver();
    }

    public IEnumerator ShowBombPanelGameOver()
    {
        gameController.GameOver();
        panelGame.SetActive(false); //desativa o painel de game
        yield return new WaitForSeconds(3f);
        panelGameOver.gameObject.SetActive(true);
    }
}
