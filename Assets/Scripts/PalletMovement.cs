using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalletMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool isplayer2;
    public bool canMoveUp;
    public bool canMoveDown;
    public BallMovement1 ball;

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float moveX = 0f;
        float moveY = 0f;

        // Move left
        if (isplayer2 != true)
        {
            /*// Move left
            if (Input.GetKey(KeyCode.A))
            {
                moveX = -moveSpeed;
            }
            // Move right
            if (Input.GetKey(KeyCode.D))
            {
                moveX = moveSpeed;
            }*/
            // Move up
            if (Input.GetKey(KeyCode.W) && canMoveUp == true)
            {
                moveY = moveSpeed;
            }
            // Move down
            if (Input.GetKey(KeyCode.S) && canMoveDown == true)
            {
                moveY = -moveSpeed;
            }
        }
        if (isplayer2 == true)
        {
            /*// Move left
            if (Input.GetKey(KeyCode.RightArrow))
            {
                moveX = -moveSpeed;
            }
            // Move right
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveX = moveSpeed;
            }*/
            // Move up
            if (Input.GetKey(KeyCode.UpArrow) && canMoveUp == true)
            {
                moveY = moveSpeed;
            }
            // Move down
            if (Input.GetKey(KeyCode.DownArrow) && canMoveDown == true)
            {
                moveY = -moveSpeed;
            }
        }
        Vector3 movement = new Vector3(moveX, moveY, 0f) * Time.deltaTime;
        transform.position += movement;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TopBound")
        {
            canMoveUp = false;
        }

        if (collision.tag == "BottomBound")
        {
            canMoveDown = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canMoveUp = true;
        canMoveDown = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isplayer2 != true)
        {
            ball.hitP1Last = true;
        }
        if (isplayer2 == true)
        {
            ball.hitP1Last = false;
        }

    }
}
