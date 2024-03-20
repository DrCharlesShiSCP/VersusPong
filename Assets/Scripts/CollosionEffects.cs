using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollosionEffects : MonoBehaviour
{
    public ParticleSystem collisionEffect; // Assign this in the Inspector
    public GameObject ParticleSystem;

    public void Start()
    {
        collisionEffect = GetComponent<ParticleSystem>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        PlayCollisionEffect();
    }

    public void PlayCollisionEffect()
    {
        if (collisionEffect != null)
        {
            // Position the particle effect at the collision point if needed
            // collisionEffect.transform.position = collision.contacts[0].point;

            //collisionEffect.Stop(); // Stop the effect to reset it
            //collisionEffect.Play(); // Play the particle effect
            ParticleSystem.SetActive(true);
            collisionEffect.Play();
            Debug.Log("Yeah particles are working");
        }
    }
}
