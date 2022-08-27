using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private Rigidbody2D myRB; //RigidBody da fruta
    [SerializeField] private float startForce; //força que é aplicada para a formiga ir para cima
    public GameObject fruitSliced; //fruta fatiada
    private GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        myRB = this.gameObject.GetComponent<Rigidbody2D>();
        gameController = FindObjectOfType<GameController>();
        ApplyForce();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void ApplyForce()
    {
        myRB.AddForce(transform.up * startForce, ForceMode2D.Impulse); //impulsionando a fruta pra cima
    }

    public Color32 ChangeSplashColor(GameObject GO)
    {
        string cloneObjectName = GO.transform.name;
        Color32 defaultColor = new Color32(255, 255, 255, 255);

        switch(cloneObjectName)
        {
            case "Apple(Clone)":
            return gameController.appleColor;

            case "Coconout(Clone)":
            return gameController.coconoutColor;

            case "Orange(Clone)":
            return gameController.orangeColor;

            case "Pear(Clone)":
            return gameController.pearColor;

            case "Pineapple(Clone)":
            return gameController.pineappleColor;
        }

        return defaultColor;
    }
    
}
