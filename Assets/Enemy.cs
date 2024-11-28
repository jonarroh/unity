using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int life = 3;
    public GameObject player;
    public GameObject deathParticlesPrefab;
    public int comportamientoActual = 1;
    public float speed = 5.0f;
    private bool siguiendoJugador = false;
    private Spawner spawner;

    void Start()
    {
        player = GameObject.Find("Player");
        comportamientoActual = Random.Range(1, 3);
        InvokeRepeating("cambiarDireccion", 3, 3);

        // Configuración inicial del movimiento
        ActualizarMovimiento();
    }

    void ActualizarMovimiento()
    {
        if (comportamientoActual == 1)
        {
            siguiendoJugador = true;
            transform.LookAt(player.transform);
            GetComponent<Rigidbody>().velocity = transform.forward * speed;
        }
        else if (comportamientoActual == 2)
        {
            siguiendoJugador = false;
            GetComponent<Rigidbody>().velocity = transform.forward * speed * 2;
        }
        else
        {
            siguiendoJugador = false;
            GetComponent<Rigidbody>().velocity = transform.forward * speed;
        }
    }

    public void cambiarDireccion()
    {
        // Solo cambiar dirección si no está siguiendo al jugador
        if (!siguiendoJugador)
        {
            transform.Rotate(0, Random.Range(0, 360), 0);
            // Actualizar la velocidad después de rotar
            GetComponent<Rigidbody>().velocity = transform.forward * speed;
        }
    }

    void Update()
    {
        if (player != null && siguiendoJugador)
        {
            transform.LookAt(player.transform);
            GetComponent<Rigidbody>().velocity = transform.forward * speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            
            FindAnyObjectByType<PlayerHelth>().TakeDamage();
        }
        if (collision.collider.CompareTag("Bala"))
        {
            life--;
            if (life <= 0)
            {
                GameObject particles = Instantiate(deathParticlesPrefab, transform.position, Quaternion.identity);
                Destroy(particles, 1.0f);
                Destroy(gameObject);
                spawner.currentEnemy++;
            }
        }
    }
}