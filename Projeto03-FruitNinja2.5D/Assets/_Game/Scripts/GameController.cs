using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject splash;
    [HideInInspector] public Color32 
                                    appleColor = new Color32(139, 18, 8, 255), 
                                    coconoutColor = new Color32(101, 64, 40, 255), 
                                    orangeColor =  new Color32(255, 131, 13, 255), 
                                    pineappleColor = new Color32(185, 101, 23, 255),
                                    pearColor = new Color32(173, 184, 0, 255),
                                    uIRedColor = new Color32(255, 0, 0, 255),
                                    uIWhiteColor = new Color32(255, 255, 255, 255); //cor das vidas que o jogador vai perdendo que vai ficando vermelho
    
    private UIController uIController;
    [HideInInspector] public int score, fruitCount;
    [SerializeField] private GameObject fruitSpawner, blade, destroyer;

    // Start is called before the first frame update
    void Start()
    {
        uIController = FindObjectOfType<UIController>();
        score = 0;
        fruitCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        uIController.txtScore.text = "Score: " + score;
    }

    public void UpdateScore(int points)
    {
        score += points;
        uIController.txtScore.text = "Score: " + score.ToString();
    }

    public void GameOver()
    {
        fruitSpawner.gameObject.SetActive(false); //desativa o objeto que cria as frutas e as bombas
        destroyer.SetActive(false);
        blade.SetActive(false);
    }

    public void RestartGame()
    {
        score = 0;
        fruitCount = 0;
        uIController.txtScore.text = "Score: " + score.ToString();
        fruitSpawner.gameObject.SetActive(true); //desativa o objeto que cria as frutas e as bombas
        destroyer.SetActive(true);
        blade.SetActive(true);
    }
}
