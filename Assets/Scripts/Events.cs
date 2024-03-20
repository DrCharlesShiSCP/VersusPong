using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public CircularTimer timer;
    public string nextScene;
    public void Reset()
    {
        timer.PauseTimer();
        SceneManager.LoadScene(nextScene);
    }
    private void Start()
    {
        timer.StartTimer();
    }

}
