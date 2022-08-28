using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCollider : MonoBehaviour
{
    private Bomb bomb;

    private void Start() {
        bomb = this.gameObject.GetComponent<Bomb>();
    }
    private void OnTriggerEnter2D(Collider2D target) 
    { 
        if(target.gameObject.CompareTag("Blade"))//se o jogador tocar na bomba
        {
            bomb.BombGameOver(); //vai chamar o método para criar o game over
        }
    }
}
