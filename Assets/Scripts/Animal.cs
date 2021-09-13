using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool movingRight;
    [SerializeField] GameManager gm;
    [SerializeField] GameObject animal;
    
    float minX, maxX;
    public float vida;
    public float vidaMaxima;

    public GameObject barraDeVidaUI;
    public Slider barra;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinaSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinaSupDer.x;
        minX = esquinaInfIzq.x;

        vida = vidaMaxima;
        barra.value = CalcularVida();
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();

        //this.transform.t

        barra.value = CalcularVida();

        if (vida < vidaMaxima)
        {
            barraDeVidaUI.SetActive(true);
        }

        if (vida > vidaMaxima)
        {
            vida = vidaMaxima;
        }
    }

    void MoveEnemy()
    {
        if (movingRight)
        {
            transform.Translate(new Vector2(speed * Time.deltaTime, 0), Space.World);
        }
        else
            transform.Translate(new Vector2(-speed * Time.deltaTime, 0), Space.World);

        if (transform.position.x > maxX)
        {
            movingRight = false;
        }
        else if (transform.position.x < minX)
        {
            movingRight = true;
        }

        /*if (indicador == false)
        {
            
        }
        else
        {
            if (movingRight)
            {
                transform.Translate(new Vector2((speed * Time.deltaTime)/2, 0), Space.World);
            }
            else
                transform.Translate(new Vector2((-speed * Time.deltaTime)/2, 0), Space.World);

            GameObject gravedad = gravedad.gameObject; 
        }*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject colisionando = collision.gameObject;
        if(colisionando.tag == "Disparo" || colisionando.tag == "Rafaga" || colisionando.tag == "Automatico")
        {
            vida--;
            if (vida <= 0)
            {
                gm.ReducirNumEnemies();
                Destroy(this.gameObject);
            }                                 
        }
    }

    float CalcularVida()
    {
        return vida / vidaMaxima; 
    }
}
