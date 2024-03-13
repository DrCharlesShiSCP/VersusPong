using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
        public float moveSpeed = 5f;

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
            if (Input.GetKey(KeyCode.A))
            {
                moveX = -moveSpeed;
            }
            // Move right
            if (Input.GetKey(KeyCode.D))
            {
                moveX = moveSpeed;
            }
            // Move up
            if (Input.GetKey(KeyCode.W))
            {
                moveY = moveSpeed;
            }
            // Move down
            if (Input.GetKey(KeyCode.S))
            {
                moveY = -moveSpeed;
            }

            Vector3 movement = new Vector3(moveX, moveY, 0f) * Time.deltaTime;
            transform.position += movement;
        }
}
