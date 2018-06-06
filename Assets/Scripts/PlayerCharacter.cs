using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] float speed;
    float horizontal;
    float horizontalMovement;
    bool flipped;

    Rigidbody2D body;
    SpriteRenderer spriteRenderer;

    [SerializeField] GameObject PlayerLaser;

    void Start ()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        body = this.GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        flipped = spriteRenderer.flipX;
        horizontal = Input.GetAxis("Horizontal");
        horizontalMovement = speed * horizontal;

        if (horizontal > 0 && flipped)
        {
           spriteRenderer.flipX = false;
        }
        if (horizontal < 0 && !flipped)
        {
            spriteRenderer.flipX = true;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(horizontalMovement, 0);
    }

    void Shoot()
    {
        Instantiate(PlayerLaser, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation);
    }
}
