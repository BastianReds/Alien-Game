using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool movingRight;
    [SerializeField] GameManager gm;

    float minX, maxX;
    int puntosDeVida = 5;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinaSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinaSupDer.x;
        minX = esquinaInfIzq.x;
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject colisionando = collision.gameObject;
        if(colisionando.tag == "Disparo" || colisionando.tag == "Rafaga")
        {
            gm.ReducirNumEnemies();
            Destroy(this.gameObject);
        }

    }
}
