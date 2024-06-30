using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorByTrigger : MonoBehaviour
{
    [SerializeField] private GameObject desintegrate;

    public void Open()
    {
        Instantiate(desintegrate,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
