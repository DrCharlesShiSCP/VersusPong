using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollosionEffects : MonoBehaviour
{
    public ParticleSystem collisionEffect; // Assign this in the Inspector

    private void Start()
    {
        collisionEffect = GetComponent<ParticleSystem>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayCollisionEffect();
    }

    void PlayCollisionEffect()
    {
        if (collisionEffect != null)
        {
            // Position the particle effect at the collision point if needed
            // collisionEffect.transform.position = collision.contacts[0].point;

            collisionEffect.Stop(); // Stop the effect to reset it
            collisionEffect.Play(); // Play the particle effect
        }
    }
}
