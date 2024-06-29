using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicManager : MonoBehaviour
{

    [SerializeField] private GameObject[] images;
    [Range(1f, 15f)][SerializeField] private float timeToChange;

    private float currentTimeToChange;
    private int currentSlide = 1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseComic();
        }
    }

    public void CloseComic()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
