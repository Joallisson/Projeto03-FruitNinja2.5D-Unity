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
                                    pearColor = new Color32(173, 184, 0, 255);
    
    private UIController uIController;
    [HideInInspector] public int score;
    // Start is called before the first frame update
    void Start()
    {
        uIController = FindObjectOfType<UIController>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        uIController.txtScore.text = "Score: " + score;
    }
}
