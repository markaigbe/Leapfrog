using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody Player;
    public float jumpForce;
    public float gravityMod;
    public bool gameOver = false;
    //public bool isOnGround = true;
    private Animator playerAnim;
    private MoveSnakesBack stopPlayer;

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody>();
        Physics.gravity *= gravityMod;
        //playerAnim = GetComponent<Animator>();
        stopPlayer = GameObject.Find("SnakeObstacle").GetComponent<MoveSnakesBack>();
    }

    // Update is called once per frame
    void Update()
    {

        if(stopPlayer.gameOver == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Player.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //playerAnim.SetTrigger("Jump_Trig");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //isOnGround = true;
        }else if (collision.gameObject.CompareTag("SnakeObstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            /*playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);*/
        }
    }
}
