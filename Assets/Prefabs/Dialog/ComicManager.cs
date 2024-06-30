using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using platformer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComicManager : MonoBehaviour
{

    [SerializeField] private GameObject[] images;
    [Range(1f, 15f)][SerializeField] private float timeToChange;
    [SerializeField] private bool destroyOnRestart = false;

    [SerializeField] private bool isTutorial = false;

    private float currentTimeToChange;
    private int currentSlide = 1;

    private void Start()
    {
        if (PlayerPrefs.HasKey("checkpoint") && isTutorial)
        {
            gameObject.SetActive(false);
        }
    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            foreach (var img in images)
            {
                img.SetActive(false);
            }
            //print(Time.deltaTime);
            if (currentSlide < images.Length)
            {
                currentTimeToChange -= Time.deltaTime;
                images[currentSlide].SetActive(true);
                currentTimeToChange = timeToChange;
            }
            else
            {
                CloseComic();
            }

            currentSlide++;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CloseComic();
        }
    }

    public void CloseComic()
    {
        foreach (var img in images)
        {
            img.SetActive(false);
        }

        images[0].SetActive(true);
        currentSlide = 0;
        Time.timeScale = 1;
        
        gameObject.SetActive(false);
        GameManager.Instance.player.GetComponent<PlayerController>().enabled = true;
        
    }
}
