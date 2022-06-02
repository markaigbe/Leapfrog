using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour
{
    // otherComponents
    private Animator playerAnim;
    private Rigidbody Player;
    private Rigidbody Cube;

    // particles
    public ParticleSystem explosion;

    // audio
    private AudioSource audio;
    public AudioClip jump;
    public AudioClip crash;

    // GameObjects
    public List<GameObject> objects;

    // tmproGuis
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverScreen;

    public GameObject titleScreen;
    public GameObject countScreen;
    public GameObject scoreScreen;
    public GameObject deathScreen;

    // buttons
    public Button restartButton;
    public Button easyButton;

    // primDataTypes
    public float timer = 0;
    public float jumpForce;
    public float gravityMod;
    public int score = 0;
    public bool gameOver = false;
    public bool timerReached = false;
    public bool onGround = false;

    // initialising our components
    void Start()
    {

    }

    // game functions
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void StartGame()
    {
        // gathering components so i can apply them using this script
        Player = GetComponent<Rigidbody>();
        Cube = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();

        // making my 
        titleScreen.gameObject.SetActive(false);
        scoreScreen.gameObject.SetActive(true);
        countScreen.gameObject.SetActive(true);

        Physics.gravity *= gravityMod;
        scoreText.text = "Score: " + score;

    }



    void Update()
    {
        // fine
        // jump mechanics + cast jump animation
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            Player.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_Trig");
            audio.PlayOneShot(jump, 1.0f);

        }
   
    }


    // fine
    // game over/collision method + cast death animation + score counter!
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            score = score + 1;
            scoreText.text = "Score: " + score;

            // to display lvl diff 0 when player passes through first obstacle
            Debug.Log("Score: " + score);
        }

        if (collision.gameObject.CompareTag("SnakeObstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_a", true);
            playerAnim.SetInteger("DeathType_int", 1);
            audio.PlayOneShot(crash, 1.0f);
            explosion.Play();
            Destroy(Player);
            restartButton.gameObject.SetActive(true);
            gameOverScreen.gameObject.SetActive(true);
            deathScreen.gameObject.SetActive(true);
        }
    }
}
