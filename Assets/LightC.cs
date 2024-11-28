using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    { 
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log(GetComponent<Light>().enabled.ToString());
            GetComponent<Light>().enabled = !GetComponent<Light>().enabled;

        }
        
    }
}
