using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveSnakesBack : MonoBehaviour
{
    private GameController playerControllerScript;

    public float speed = 30;
    public bool gameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

    }

}

