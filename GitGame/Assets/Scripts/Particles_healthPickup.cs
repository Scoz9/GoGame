using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles_healthPickup : MonoBehaviour
{
    public ParticleSystem particles;
    public SpriteRenderer sprite;
    private bool once = true;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (HealthManager.instance.currentHealth == HealthManager.instance.maxHealth) return;
        else if (collision.gameObject.CompareTag("Player") && once) {
            HealthManager.instance.currentHealth++;

            var emission = particles.emission;
            var duration = particles.duration;

            emission.enabled = true;
            particles.Play();

            once = false;
            Destroy(sprite);
            Invoke(nameof(DestroyObj), duration); //Distrugge l'oggetto dopo che sia passato il tempo necessario al particleSystem
        }
    }

    void DestroyObj () { Destroy(gameObject); }
}
