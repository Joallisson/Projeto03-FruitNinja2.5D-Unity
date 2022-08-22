using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollider : MonoBehaviour
{
    private Fruit fruit;
    // Start is called before the first frame update
    void Start()
    {
        fruit = this.gameObject.GetComponent<Fruit>();
    }

    private void OnTriggerEnter2D(Collider2D target) //quando eu triscar em uma fruta
    {
        if (target.gameObject.CompareTag("Blade")) //se eu triscar na fruta
        {
            GameObject tempFruitSliced = Instantiate(fruit.fruitSliced, transform.position, Quaternion.identity); //criar uma fruta fatiada
            tempFruitSliced.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().AddForce(-tempFruitSliced.transform.GetChild(0).transform.right * Random.Range(5f, 10f), ForceMode.Impulse);
            tempFruitSliced.transform.GetChild(1).gameObject.GetComponent<Rigidbody>().AddForce(tempFruitSliced.transform.GetChild(1).transform.right * Random.Range(5f, 10f), ForceMode.Impulse);
            Destroy(this.gameObject);
            Destroy(tempFruitSliced, 5f);
        }
    }
}
