using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BigEnemy : MonoBehaviour
{

    public GameObject item;
    public int velocidad;
    public int vida = 5;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(item.transform);
        GetComponent<Rigidbody>().velocity = transform.right * velocidad;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bala")
        {

            Destroy(collision.gameObject);
            vida = vida - 1;
            if (vida == 0)
            {
                Destroy(gameObject);
            }
        }

        if (collision.collider.tag == "Player")
        {
            FindAnyObjectByType<PlayerHelth>().TakeDamage();
        }


    }
}