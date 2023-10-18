using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float increaseFactor;
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Player>().SizePowerUp(increaseFactor);
        Destroy(gameObject);
    }

}
