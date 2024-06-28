using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    [SerializeField] private CharacterDialog dialogCharacterText;
    [SerializeField] private List<string> phrases;
    //[SerializeField] private bool is_3D = false;

    [SerializeField] private bool is_player_speaking;
    [SerializeField] private bool hasObjectsToActive;
    [SerializeField] private bool hasObjectsToInactive;

    private void Start()
    {
        if (is_player_speaking)
        {
            dialogCharacterText = GameObject.Find("DialogsCanvas").GetComponent<CharacterDialog>();
        }
    }

    public void StartTextFromButton()
    {
        dialogCharacterText.GetComponent<CharacterDialog>().StartText(phrases);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogCharacterText.GetComponent<CharacterDialog>().StartText(phrases);
            if (hasObjectsToActive)
            {
                GetComponent<ObjectsToActiveInactive>().ActiveObjects();
            }
            if (hasObjectsToInactive)
            {
                GetComponent<ObjectsToActiveInactive>().InactiveObjects();
            }
            
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogCharacterText.GetComponent<CharacterDialog>().StartText(phrases);
            if (hasObjectsToActive)
            {
                GetComponent<ObjectsToActiveInactive>().ActiveObjects();
            }
            if (hasObjectsToInactive)
            {
                GetComponent<ObjectsToActiveInactive>().InactiveObjects();
            }

            Destroy(gameObject);
        }
    }
}
