using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : MonoBehaviour
{
 

    // Update is called once per frame
    void Update()
    {

        //button pause
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        //button speed up
        if (Input.GetKeyDown(KeyCode.F))
        {
            Time.timeScale = 2;
        }
        //button speed down
        if (Input.GetKeyDown(KeyCode.S))
        {
            Time.timeScale = 0.5f;
        }

    }
}
