using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public string nextScene;
    public void Reset()
    {
        SceneManager.LoadScene(nextScene);
    }

}
