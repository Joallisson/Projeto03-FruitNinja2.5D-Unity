using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] fruitsPrefab; //esse array vai guardar as frutas
    [SerializeField] private Transform[] spawnPoints; //esse array vai guardar os objetos de onde as frutas serão instanciadas
    [SerializeField] private float minDelay, maxDelay; //intervalo de tempo em que as frutas serão instanciadas
    private GameController gameController;
    [HideInInspector] public Coroutine spawnCorotine;

    private void Awake() {
        gameController = FindObjectOfType<GameController>();
    }

    public IEnumerator Spawn() //Esse método instancia novas frutas
    {
        while(gameController.gameStart)
        {
            float delay = Random.Range(minDelay, maxDelay); //intervalo de tempo entre cada instacia das frutas
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length); //escolhendo o index de qual ponto do spawn será usado para criar as frutas
            Transform spawnPoint = spawnPoints[spawnIndex]; //selecionando um dos pontos para instaciar a fruta

            GameObject fruitPrefab = Instantiate(fruitsPrefab[Random.Range(0, fruitsPrefab.Length)], spawnPoint.position, spawnPoint.rotation); //instanciando uma das frutas do array
            fruitPrefab.transform.parent = gameController.allObjects;
            spawnPoint.gameObject.GetComponent<AudioSource>().Play(); //tocando áudio depois que as frutas são instânciadas
            Destroy(fruitPrefab, 5f); //destruindo fruta
        }
    }
}
