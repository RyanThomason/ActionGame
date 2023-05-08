using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Player Variables
    public CharacterController controller;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    public float speed = 10f;
    Vector3 velocity;
    bool isGrounded;
    public int coins;

    //Coin text
    public Text coinTxt;

    void Start() {
        coins = 300;
    }


    // Update is called once per frame
    void Update()
    {

        //set the coin text to update on kill
        coinTxt.text = "Coins: " + coins.ToString();

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void AddCoins(int numCoins) {
        
    }
}
