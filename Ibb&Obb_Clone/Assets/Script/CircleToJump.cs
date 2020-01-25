using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleToJump : MonoBehaviour
{

    [SerializeField] private float jumpForce;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // transform -> GetComponentTransform
        // Vecteur * float (tout composant)
        
        other.GetComponent<Rigidbody2D>().AddForce(other.transform.up * jumpForce);
    }
}
