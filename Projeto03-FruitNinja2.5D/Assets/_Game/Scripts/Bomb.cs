using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float speed, startForce; //velocidade de rotação da bomba
    [SerializeField] private GameObject beamLight; //a faísca da bomba
    private Rigidbody2D myRB;
    private AudioController audioController;
    // Start is called before the first frame update
    void Start()
    {
        myRB = this.gameObject.GetComponent<Rigidbody2D>();
        audioController = FindObjectOfType<AudioController>();
        ApplyForce();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(new Vector3(0f, speed, 0f) * Time.deltaTime);
    }

    private void ApplyForce()
    {
        myRB.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }

    public void BombGameOver() //Quando o jogador tocar na bomba
    {
        speed = 0f; // a velocidade fica em zero
        myRB.bodyType = RigidbodyType2D.Kinematic; //seta o Rigidbody2D para o objeto não cair
        myRB.simulated = false; //para a bomba completamente
        CircleCollider2D myCollider = this.gameObject.GetComponent<CircleCollider2D>(); ////pega o componente CircleCollider2D da bomba
        myCollider.enabled = false; //desativa o CircleCollider2D da bomba
        GameObject tempBeamLight = Instantiate(beamLight, this.gameObject.transform.position, Quaternion.identity) as GameObject; //instanciando a bomba
        this.gameObject.GetComponent<AudioSource>().clip = audioController.bombExplodeAudio; //pegando áudio da bomba
        this.gameObject.GetComponent<AudioSource>().Play(); //tocando o áudio da bomba
    }
}
