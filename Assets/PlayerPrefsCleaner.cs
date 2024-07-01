using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsCleaner : MonoBehaviour
{
    public void Clear()
    {
        PlayerPrefs.DeleteAll();
    }
}
