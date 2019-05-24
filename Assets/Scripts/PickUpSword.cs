using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSword : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject buttonAttackMele;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            buttonAttackMele.SetActive(true);
        }
    }
}
