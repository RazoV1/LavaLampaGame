using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseFunctions : MonoBehaviour
{
    public void ToScene(int ind)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(ind);
    }


}
