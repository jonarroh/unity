using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] setPoins;
    public float speed = 2;
    private int setPointIndex = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
        
    }


    public void OncollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }



    public void MovePlatform()
    {
        if (Vector3.Distance(transform.position, setPoins[setPointIndex].transform.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, setPoins[setPointIndex].transform.position, speed * Time.deltaTime);
        }
        else
        {
            setPointIndex++;
            if (setPointIndex >= setPoins.Length)
            {
                setPointIndex = 0;
            }
        }
    }
}
