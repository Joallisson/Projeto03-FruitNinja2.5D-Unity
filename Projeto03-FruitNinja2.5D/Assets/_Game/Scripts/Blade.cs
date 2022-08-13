using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private TrailRenderer trailRenderer;
    private CircleCollider2D circleCollider;
    private Vector2 previousPosition;
    [SerializeField] private float minCuttingVelocity = 0.001f;

    private void Awake() {
        trailRenderer = this.gameObject.GetComponent<TrailRenderer>();
        circleCollider = this.gameObject.GetComponent<CircleCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        trailRenderer.enabled = false;
        circleCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        cutSystem();
    }

    private void cutSystem()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) //se eu tocar na tela
        {
            UpdateCut();
        }
        else if(Input.touchCount == 0){ //se eu não estiver mais tricando na tela
            StopCut();
        }
    }

    private void UpdateCut()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position); 
        this.transform.position = newPosition;
        float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;

        if(velocity > minCuttingVelocity) //se o jogador tiver movendo o dedo muito lentamente
        {
            circleCollider.enabled = true;
            trailRenderer.enabled = true;
        }
        else{ //se o jogador tiver movendo o dedo rapido
            circleCollider.enabled = false;
            trailRenderer.enabled = false;
        }

        previousPosition = newPosition; //posição anterior recebe nova posição
    }

    private void StopCut()
    {
        if(this.transform.position == null)
        {
            this.transform.position = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        }

         circleCollider.enabled = false;
        trailRenderer.enabled = false;
    }
}
