using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject disparo;
    [SerializeField] GameObject rafaga;
    [SerializeField] GameObject automatico;
    [SerializeField] float cadencia;
    [SerializeField] int municion;

    float minX, maxX, minY, maxY;
    float contador;
    float nextFire = 0;
    int modoDisp = 1;

    public bool gamePaused = false;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinaSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinaSupDer.x - 0.05f;
        maxY = esquinaSupDer.y - 0.65f;
        minX = esquinaInfIzq.x + 0.05f;
        
        Vector2 puntoX = Camera.main.ViewportToWorldPoint(new Vector2(0, 0.2f));
        minY = puntoX.y;

    }

    // Update is called once per frame
    void Update()
    {
        if (!gamePaused)
        { 
            Mover();

            switch (modoDisp)
            {
                case 1:
                    Disparar();
                    break;

                case 2:
                    Rafaga();
                    break;

                case 3:
                    Automatico();
                    break;
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                modoDisp = 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                modoDisp = 2;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                modoDisp = 3;
            }

            /*if (modoDisp)
                Disparar();

            else 
                Rafaga();
       
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (modoDisp)
                    modoDisp = false;
                else
                    modoDisp = true;               
            }*/
        }             
    }

    void Mover()
    {
        float dirH = Input.GetAxis("Horizontal");
        float dirV = Input.GetAxis("Vertical");

        Vector2 movimiento = new Vector2(dirH * Time.deltaTime * speed, dirV * Time.deltaTime * speed);
        transform.Translate(movimiento);

        if (transform.position.x > maxX)
            transform.position = new Vector2(minX, transform.position.y);

        if (transform.position.x < minX)
            transform.position = new Vector2(maxX, transform.position.y);

        if (transform.position.y > maxY)
            transform.position = new Vector2(transform.position.x, maxY);

        if (transform.position.y < minY)
        {
            transform.position = new Vector2(transform.position.x, minY);
        }
    }

    void Disparar()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFire)
        {
            Instantiate(disparo, transform.position - new Vector3(0, 0.3f, 0), transform.rotation);
            nextFire = Time.time + cadencia;
        }
    }

    void Rafaga()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFire)
        {
            if (municion>0)
            {
                Instantiate(rafaga, transform.position - new Vector3(0, 0.3f, 0), transform.rotation);
                nextFire = Time.time + cadencia / 3;

                municion--;

                if (municion == 0)
                {
                    nextFire = Time.time + 2;
                    municion = 5;
                }
            }
        }
    }

    void Automatico()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFire)
        {
            if (municion > 0)
            {
                Instantiate(automatico, transform.position - new Vector3(0, 0.3f, 0), transform.rotation);
                nextFire = Time.time + cadencia / 3;

                municion--;

                if (municion == 0)
                {
                    nextFire = Time.time + 4;
                    municion = 8;
                }
            }
        }
    }
}
