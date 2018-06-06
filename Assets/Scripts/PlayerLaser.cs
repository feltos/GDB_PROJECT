using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D body;
    Vector2 direction = new Vector2(0, 1);
    Vector2 movement;

	void Start ()
    {
        body = this.GetComponent<Rigidbody2D>();
    }
	
	void Update ()
    {
        movement = new Vector2(speed * direction.x, speed * direction.y);
	}

    void FixedUpdate()
    {
        body.velocity = movement;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == LayerMask.NameToLayer("ennemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
