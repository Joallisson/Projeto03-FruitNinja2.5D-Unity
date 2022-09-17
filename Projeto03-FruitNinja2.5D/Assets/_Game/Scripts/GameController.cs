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
    private int highscore;
    private GameData gameData;
    public Transform allObjects, allSplashes, allSlicedFruits, allLightBeams;
    [HideInInspector] public bool soundOnOff, gameStart;
    private FruitSpawner fruitSpawnerScript;

    // Start is called before the first frame update
    void Start()
    {
        soundOnOff = true;
        gameStart = false;
        uIController = FindObjectOfType<UIController>();
        fruitSpawnerScript = FindObjectOfType<FruitSpawner>();
        gameData = FindObjectOfType<GameData>();
        highscore = gameData.GetScore();
        score = 0;
        fruitCount = 0;
        Initialize();
        SoundsData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   private void Initialize()
   {
        int soundValue = gameData.GetSounds();
        if (soundValue == 1)
        {
            soundOnOff = true;
            uIController.btnSoundsMenuPause.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = uIController.imgSoundOn;
            uIController.btnSoundsMainMenu.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = uIController.imgSoundOn;
        }
        else
        {
            soundOnOff = false;
            uIController.btnSoundsMenuPause.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = uIController.imgSoundOff;
            uIController.btnSoundsMainMenu.gameObject.GetComponent<UnityEngine.UI.Image>().sprite = uIController.imgSoundOff;
        }
   }

    public void StartGame()
    {
        RestartGame();
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
        gameStart = false;
        StopCoroutine(fruitSpawnerScript.spawnCorotine);

        if(score > highscore)
        {
            gameData.SaveScore(score);
        }
    }

    public void RestartGame()
    {
        score = 0;
        fruitCount = 0;
        fruitSpawner.gameObject.SetActive(true); //desativa o objeto que cria as frutas e as bombas
        destroyer.SetActive(true);
        blade.SetActive(true);
        gameStart = true;
        fruitSpawnerScript = FindObjectOfType<FruitSpawner>();
        fruitSpawnerScript.spawnCorotine = StartCoroutine(fruitSpawnerScript.Spawn());

        foreach(Transform child in allLightBeams)
        {
            Destroy(child.gameObject);
        }
    }

    public void SoundsData()
    {
        if (soundOnOff)
        {
            gameData.SaveSounds(1);
            soundOnOff = true;
        }
        else
        {
            gameData.SaveSounds(0);
            soundOnOff = false;
        }
    }

    public void BackMainMenu()
    {
        score = 0;
        fruitCount = 0;
        fruitSpawner.gameObject.SetActive(false);
        blade.gameObject.SetActive(false);
        destroyer.gameObject.SetActive(false);
        Time.timeScale = 1f;
        gameStart = false;
        StopCoroutine(fruitSpawnerScript.spawnCorotine);

        foreach(Transform child in allObjects)
        {
            Destroy(child.gameObject);
        }

        foreach(Transform child in allSlicedFruits)
        {
            Destroy(child.gameObject);
        }

        foreach(Transform child in allSplashes)
        {
            Destroy(child.gameObject);
        }

        foreach(Transform child in allLightBeams)
        {
            Destroy(child.gameObject);
        }
    }
}
