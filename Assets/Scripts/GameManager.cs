using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public CinemachineVirtualCamera playerCamera;
    public float camSize;

    public BulletProvider BulletProvider;

    public GameObject player;

    public int[] bugNumbers;
    public string[] bugStrings;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("More than one GameManager by name: " + gameObject.name);
            Destroy(gameObject);
        }
    }
}
