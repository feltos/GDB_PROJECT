using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] float speed;
    float horizontal;
    float horizontalMovement;

    Rigidbody2D body;
    SpriteRenderer spriteRenderer;

    [SerializeField] GameObject PlayerLaser;

    float screenHeight;

    void Start ()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        body = this.GetComponent<Rigidbody2D>();
        screenHeight = Screen.height;
	}
	
	void Update ()
    {
        horizontal = Input.GetAxis("Horizontal");
        horizontalMovement = speed * horizontal;

        int i = 0;
        while(i < Input.touchCount)
        {
            if(Input.GetTouch(i).position.x > screenHeight / 2)
            {
                //move right
                spriteRenderer.flipX = false;
            }
            if (Input.GetTouch(i).position.x < screenHeight / 2)
            {
                //move left
                spriteRenderer.flipX = true;
                Debug.Log("touch left");
            }
            i++;
        }
       if(Input.GetKeyDown(KeyCode.Space))
       {
           Shoot();
       }
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(horizontalMovement * speed, 0);
    }

    void Shoot()
    {
        Instantiate(PlayerLaser, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation);
    }
}
