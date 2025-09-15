using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFuncs : MonoBehaviour
{
    public void ChangeScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}
