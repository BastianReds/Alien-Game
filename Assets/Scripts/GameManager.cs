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
    [SerializeField] int numEnemies;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && gameOver == false)
            PauseGame();
    }

    public void StartGame()
    {
        SceneManager.LoadScene (1);
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
        Debug.Log("Ganaste");
    }
}
