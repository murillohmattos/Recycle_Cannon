using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    private static GameManager instance;
    public static GameManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public TMP_Text coreText;
    public GameObject gameOverScreen; 
    int coreLife = 20;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        coreText.text = coreLife.ToString("0");
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (coreLife <= 0)
        {
            gameOverScreen.SetActive(true);

            Time.timeScale = 0;
        }        
    }

    public void CoreTakeDamage() 
    {
        coreLife--;
        coreText.text = coreLife.ToString();
    }

    public void ResetGame() 
    {        
        SceneManager.LoadScene(1);
    }
    public void ExitGame() 
    {
        Application.Quit();
    }
}
