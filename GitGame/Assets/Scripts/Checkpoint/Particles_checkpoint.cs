using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles_checkpoint : MonoBehaviour
{
    private ParticleSystem particle;   
    private bool once = true;

    private void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && once)
        {
            var main = particle.main;
            main.startColor = Color.green;
            once = false;
        }
    }
}
