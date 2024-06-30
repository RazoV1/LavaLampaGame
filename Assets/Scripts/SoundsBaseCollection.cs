using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

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

    
    public static SoundsBaseCollection Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
}
