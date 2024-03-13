using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollisionDetection : MonoBehaviour
{
    private int player1life;
    private int player2life;
    public TextMeshProUGUI player1health;
    public TextMeshProUGUI player2health;

    private void Start()
    {
        player1life = 3;   
        player2life = 3;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object is player backwall
        if (collision.gameObject.CompareTag("playerwall1") && player1life <= 0) 
        {
            Kill1();

        }else if(collision.gameObject.CompareTag("playerwall2") && player2life <= 0)
        {
            Kill2();
        }
        if (collision.gameObject.CompareTag("playerwall1") && player1life >= 0)
        {
            UpdateHealth1Display();

        }
        else if (collision.gameObject.CompareTag("playerwall2") && player2life >= 0)
        {
            UpdateHealth2Display();
        }
    }

    void Kill1()
    {
        
        Debug.Log("Player1 has been killed!");
    }
    void Kill2()
    {

        Debug.Log("Player2 has been killed!");
    }
    void UpdateHealth1Display()
    {
        player1health.text = "Health: " + player1life.ToString();
    }
    void UpdateHealth2Display()
    {
        player2health.text = "Health: " + player2life.ToString();
    }
}
