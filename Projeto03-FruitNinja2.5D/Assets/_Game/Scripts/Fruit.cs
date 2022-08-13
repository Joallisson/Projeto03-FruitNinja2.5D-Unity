using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private Rigidbody2D myRB; //RigidBody da fruta
    [SerializeField] private float startForce; //força que é aplicada para a formiga ir para cima
    // Start is called before the first frame update
    void Start()
    {
        myRB = this.gameObject.GetComponent<Rigidbody2D>();
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
}
