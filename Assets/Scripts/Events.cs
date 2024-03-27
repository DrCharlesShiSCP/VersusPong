using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public CircularTimer timer;
    public string nextScene;
    public bool isMenu;
    public void Reset()
    {
        if (isMenu != true)
        {
            timer.PauseTimer();
        }
        SceneManager.LoadScene(nextScene);
    }
    private void Start()
    {
        if (isMenu != true)
        {
            timer.StartTimer();
        }
    }

}
