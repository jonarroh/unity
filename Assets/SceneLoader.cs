using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public string SceneName;
    

    public void OnChangeScene()
    {
        SceneManager.LoadScene(SceneName);
    }

}
