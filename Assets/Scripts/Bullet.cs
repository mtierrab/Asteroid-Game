using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullett : MonoBehaviour
{
    private float bulletLife = 1f;
    void Awake()
    {
        Destroy(gameObject, bulletLife);
    }
}
