using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollider : MonoBehaviour
{
    private Fruit fruit;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        fruit = this.gameObject.GetComponent<Fruit>(); //pegando compoenente
        gameController = FindObjectOfType<GameController>(); //pegando objeto
    }

    private void OnTriggerEnter2D(Collider2D target) //quando eu triscar em uma fruta
    {
        if (target.gameObject.CompareTag("Blade")) //se eu triscar na fruta
        {
            GameObject tempFruitSliced = Instantiate(fruit.fruitSliced, transform.position, Quaternion.identity); //criar uma fruta fatiada na posição da fruta inteira
            GameObject tempSplash = Instantiate(gameController.splash, tempFruitSliced.transform.position, Quaternion.identity); //criar splash na posição da fruta inteira
            tempSplash.GetComponentInChildren<SpriteRenderer>().color = fruit.ChangeSplashColor(this.gameObject); //manda a fruta inteira para a função ChangeSplashColor onde ela vai ver o nome da fruta e vai retornar a cor da fruta dela 

            gameController.UpdateScore(this.gameObject.GetComponent<Fruit>().points);

            tempFruitSliced.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().AddForce(-tempFruitSliced.transform.GetChild(0).transform.right * Random.Range(5f, 10f), ForceMode.Impulse); //uma parte da fruta partica vai para  a esquerda
            tempFruitSliced.transform.GetChild(1).gameObject.GetComponent<Rigidbody>().AddForce(tempFruitSliced.transform.GetChild(1).transform.right * Random.Range(5f, 10f), ForceMode.Impulse);  //uma parte da fruta partica vai para  a direita
            Destroy(this.gameObject); //destrói a fruta inteira assim que que toco nela
            Destroy(tempFruitSliced, 5f); //depois de 5 segundos destrói a fruta partida
        }
    }
}
