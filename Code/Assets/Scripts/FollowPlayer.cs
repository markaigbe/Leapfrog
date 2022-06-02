using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Player;
    private Vector3 offset = new Vector3(20, 9, -56); // this is to set the position of the camera in unity.

    void Start()
    {

    }

    void Update()
    {
        //this is attach the camera to the player
        transform.position = Player.transform.position + offset;
    }
}
