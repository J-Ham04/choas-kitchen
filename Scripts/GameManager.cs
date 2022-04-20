using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject pizzaPrefab;
    public GameObject burntPizzaPrefab;
    public Sprite pizza;
    public Sprite noPizza;
    float shootCooldown;
    public Transform[] pizzaFP = new Transform[3];
    public Image[] pizzaUI;
    public GameObject objectiveMenu;
    public GameObject pauseMenu;
    public GameObject endScreen;
    public GameObject player;
    bool highScoreBeat;
    //Score keeping
    public int score;
    public int highScore;
    public TMP_Text scoreDisplay;
    public TMP_Text highScoreDisplay;
    //Game Timer
    public float gameTimer;
    public TMP_Text gameTimerDisplay;
    //Game Management
    bool startGame = false;
    bool endGame = false;

    // Start is called before the first frame update
    void Start()
    {

        shootCooldown = 0f;
        PlayerPrefs.GetInt("High Score", highScore);
        PlayerPrefs.DeleteKey("Session Score");
    }

    // Update is called once per frame
    void Update()
    {
        gameTimerDisplay.text = ((int)gameTimer).ToString();
        if (gameTimer > 0 && startGame == true)
        {
            gameTimer -= Time.deltaTime;
        }
        else if (gameTimer <= 0 && endGame == false) {
            GameEnd();
        }
        if(score > highScore)
        {
            highScoreBeat = true;
        }

        if (highScoreBeat == true)
        {
            highScore = score;
        }

        if (highScore > 0)
        {
            highScoreDisplay.text = highScore.ToString();
        }
        else highScoreDisplay.text = "XX";

        scoreDisplay.text = score.ToString();

        if (shootCooldown == 0 && startGame == true)
        {
            int shootSpot = UnityEngine.Random.Range(1, 4);

            if (shootSpot == 1)
            {
                StartCoroutine(PizzaShoot(pizzaFP[0]));
            }
            else if (shootSpot == 2)
            {
                StartCoroutine(PizzaShoot(pizzaFP[1]));
            }
            else if (shootSpot == 3)
            {
                StartCoroutine(PizzaShoot(pizzaFP[2]));
            }
        }
        if (startGame == false)
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<PlayerInteract>().enabled = false;
        }
        else
        {
            player.GetComponent<PlayerMovement>().enabled = true;
            player.GetComponent<PlayerInteract>().enabled = true;
        }
        if (Input.GetAxisRaw("Pause") == 1 && startGame == true)
        {
            Pause();
        }
    }

    IEnumerator PizzaShoot(Transform FP)
    {
        int pizzaChoice = UnityEngine.Random.Range(1, 4);

        Animator animator = FP.GetComponentInParent<Animator>();

        if (pizzaChoice == 1)
        {
            Instantiate(burntPizzaPrefab, FP.position, Quaternion.identity);
        }else if (pizzaChoice != 1)
        {
            Instantiate(pizzaPrefab, FP.position, Quaternion.identity);
        }
        
        pizzaPrefab.GetComponent<PizzaFling>().pizzaBox = pizza;
        shootCooldown = 50f;

        animator.SetBool("Shooting", true);

        yield return new WaitForSeconds(0.2f);

        animator.SetBool("Shooting", false);
    }
    private void FixedUpdate()
    {
        if (shootCooldown > 0f)
        {
            shootCooldown -= 1;
        }
    }
    private void GameEnd()
    {
        endGame = true;
        startGame = false;
        PlayerPrefs.SetInt("Session Score", score);
        PlayerPrefs.SetInt("High Score", highScore);
        Instantiate(endScreen, endScreen.transform.position, Quaternion.identity);

        AudioManager am = FindObjectOfType<AudioManager>();
        Sound theme = Array.Find(am.sounds, Sound => Sound.name == "Theme");
        theme.volume = 0;

        am.Play("EndTheme");
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
    public void OnObjectiveQuit()
    {
        Destroy(objectiveMenu);
        startGame = true;
    }
    public void Resume()
    {
        startGame = true;
        Destroy(pauseMenu);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        startGame = false;
    }
    private void Pause()
    {
        startGame = false;
        Instantiate(pauseMenu, pauseMenu.transform.position, Quaternion.identity);
    }
}
