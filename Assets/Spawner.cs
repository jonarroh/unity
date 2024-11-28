using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public int maxEnemy = 3;
    public int currentEnemy = 0;

    void Start()
    {
        // Iniciar la corrutina de spawn
        StartCoroutine(SpawnEnemies());
    }

    // Corrutina para generar enemigos
    IEnumerator SpawnEnemies()
    {
        while (currentEnemy < maxEnemy)
        {
            Spawn();
            yield return new WaitForSeconds(1); // Esperar 1 segundo
            currentEnemy++;
        }
    }

    void Spawn()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }

    void Update()
    {
        // Puedes dejar Update vacío si no lo necesitas
    }
}