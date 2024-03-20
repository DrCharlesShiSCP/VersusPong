using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public int blockhealth;
    public Collider2D mycollider;
    public Sprite Block3;
    public Sprite Block2;
    public Sprite Block1;
    public SpriteRenderer thisblock;
    public bool isdead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (blockhealth >= 3)
        {
            thisblock.sprite = Block3;
            thisblock.enabled = true;
            mycollider.enabled = true;
        }
        else if (blockhealth < 3 && blockhealth >= 2)
        {
            thisblock.sprite = Block2;
            thisblock.enabled = true;
            mycollider.enabled = true;
        }
        else if (blockhealth < 2 && blockhealth >= 1)
        {
            thisblock.sprite = Block1;
            thisblock.enabled = true;
            mycollider.enabled = true;
        }
        else if (blockhealth < 1 && blockhealth >= 0)
        {
            //Destroy(gameObject);
            thisblock.enabled = false;
            mycollider.enabled = false;
            if (isdead == false)
            {
                onDeath();
                isdead = true;
            }

        }
    }

    public void onDeath()
    {
       /* PowerUpManager powerUpManager = FindObjectOfType<PowerUpManager>();
        if (powerUpManager != null)
        {
            powerUpManager.ActivateRandomPowerUp();
        }*/
    }

        void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the other GameObject has a script component named "YourScriptName"
        BallMovement1 script = collision.gameObject.GetComponent<BallMovement1>();

        if (script != null)
        {
            Debug.Log("Found script on other GameObject!");
            blockhealth = blockhealth - 1;
        }
    }
}
