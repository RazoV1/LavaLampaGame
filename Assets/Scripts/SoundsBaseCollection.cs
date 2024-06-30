using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsBaseCollection : MonoBehaviour
{

    [Header("Player")]
    public AudioSource jumpSound;
    public AudioSource[] runSound;
    
    [Header("UI")]
    public AudioSource correctAnswer;
    
    [Header("Cockroaches")]
    public AudioSource cockroachRun;
    public AudioSource cockroachDie;
    
    [Header("Elder")]
    public AudioSource awakeElder;

    [Header("Gay Death")]
    public AudioSource revive;


    public static SoundsBaseCollection Instance { get; private set; }

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
}
