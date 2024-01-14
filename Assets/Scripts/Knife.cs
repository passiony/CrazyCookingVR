using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ingredient"))
        {
            var ingre = collision.collider.GetComponent<Ingredient>();
            if (ingre != null)
            {
                ingre.Cut();
            }
        }
    }
}
