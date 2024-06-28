using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Kukaracha : MonoBehaviour
{
    [SerializeField] private float speed;
    public int number;
    [SerializeField] private Transform playerPos;

    [SerializeField] private TMP_Text text;

    public bool isMoving = false;  

    public void StartDeathMarch()
    {
        isMoving = true;
    }

    public void Start()
    {
        gameObject.tag = number.ToString();
        text.text = number.ToString();
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.Translate((playerPos.position-transform.position).normalized * speed * Time.deltaTime);
        }
    }
}
