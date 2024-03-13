using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public int blockhealth;
    public Sprite Block3;
    public Sprite Block2;
    public Sprite Block1;
    public SpriteRenderer thisblock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (blockhealth >= 3)
        {
            //thisblock.sprite = Block3;
        }
        else if (blockhealth < 3 && blockhealth >= 2)
        {
            //thisblock.sprite = Block2;
        }
        else if (blockhealth < 2 && blockhealth >= 1)
        {
            //thisblock.sprite = Block1;
        }
        else if (blockhealth < 1 && blockhealth >= 0)
        {
            Destroy(gameObject);
        }
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
