using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    /**
     * Uniquement pour les calculs de physique. Pas dépendante du framerate. Pour ne pas avoir de comportement differents entre machine
     * TODO : Faire le doubleJump
     */
    private void FixedUpdate()
    {
        var horizontalInput = Input.GetAxis("Horizontal");

        // TODO : Demander si pareil que KeyCode.Space ?
        if(Input.GetButton("Jump"));

        
        float jumpVelocity = 100f;
        

        var direction = new Vector2(
                            horizontalInput,
                            0
                        ) * speed;

        // Direction en fonction de l'intervale en s. du framerate et de la physique.
        myRigidBody.velocity = direction * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("OnTriggerEnter");
        myRigidBody.gravityScale *= -1;
    }
}