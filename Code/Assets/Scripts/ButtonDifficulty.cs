using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDifficulty : MonoBehaviour
{
    private Button button;
    private GameController gameControllerScript;
    private SpawnManager spawnManagerScript;
    public Animator anim;

    void Start()
    {
        button = GetComponent<Button>();
        gameControllerScript = GameObject.Find("Player").GetComponent<GameController>();
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        button.onClick.AddListener(SetDifficulty);
    }

    void Update()
    {
        mouseClick();
    }

    // so when the player presses easy/hard button, the walking animation starts
    public void mouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Active");

        }
    }

    // set difficulty function
    void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");
        gameControllerScript.StartGame();
        spawnManagerScript.StartSpawn();
    }
}
