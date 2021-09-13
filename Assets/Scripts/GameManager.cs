using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gamePaused = false;
    bool gameOver = false;
    [SerializeField] Spaceship player;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject nextLvl;
    [SerializeField] int numEnemies;
    float waitTime = 3.0f;
    [SerializeField] float timer = 0f;
    int oportunidad = 3;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
        nextLvl.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && gameOver == false)
            PauseGame();
        
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.E) && oportunidad>0)
        {

            oportunidad--;

            if (timer < 3f)
            {
                Time.timeScale = 0.5f;
            }
            else
            {
                Time.timeScale = 1.0f;
                timer = 0f;
            }

            

            /*timer = timer + Time.deltaTime;

            if (timer < waitTime)
            {
                //timer = timer - waitTime;
                Time.timeScale = 0.5f;
            }

            if (timer == 3)
            {
                Time.timeScale = 1.0f;
                timer = 0;
                
            }*/
        }
        

        if (Input.GetMouseButtonUp(0))
        {
            Time.timeScale = 1;
            player.gamePaused = false;
        }
    }

    public void Level1()
    {
        SceneManager.LoadScene (1);
    }

    public void Level2()
    {
        SceneManager.LoadScene (2);
    }

    public void Level3()
    {
        SceneManager.LoadScene (3);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    void PauseGame()
    {
        {
            gamePaused = gamePaused ? false : true;

            player.gamePaused = gamePaused;
            
            canvas.SetActive(gamePaused);

            Time.timeScale = gamePaused ? 0 : 1;
        }
    }

    public void ReducirNumEnemies()
    {
        numEnemies = numEnemies - 1;
        if(numEnemies < 1)
        {
            Ganar();
        }
    }

    void Ganar()
    {
        gameOver = true;
        Time.timeScale = 0;
        player.gamePaused = true;
        nextLvl.SetActive(true);
    }
}
