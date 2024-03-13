using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the tag "player"
        if (collision.gameObject.CompareTag("player"))
        {
            Kill();
        }
    }

    void Kill()
    {
        // Put kill logic here
        Debug.Log("Player has been killed!");
    }
}
