using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] float speed;
    float horizontal;
    float horizontalMovement;

    Rigidbody2D body;
    SpriteRenderer spriteRenderer;

    [SerializeField] GameObject PlayerLaser;
    [SerializeField] GameObject restart;

    float screenHeight;

    UnityArmatureComponent armatureComponent;

    void Start ()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        body = this.GetComponent<Rigidbody2D>();
        screenHeight = Screen.width;
        armatureComponent = GetComponent<UnityArmatureComponent>();
        Input.multiTouchEnabled = true;
    }
	
	void Update ()
    {
        horizontal = Input.GetAxis("Horizontal");
        
        int i = 0;

        if (Input.touchCount <= 0 && armatureComponent.animationName != "IDLE")
        {
            armatureComponent.animationName = "IDLE";
            armatureComponent.animation.Play("IDLE");
        }

        if (i < Input.touchCount)
        {           
            if(Input.GetTouch(i).position.x > screenHeight / 2)
            {
                //move right
                horizontal = 1;
                armatureComponent.armature.flipX = false;
                if(armatureComponent.animation.isPlaying && armatureComponent.animationName != "COURSE")
                {
                    armatureComponent.animationName = "COURSE";
                    armatureComponent.animation.Play("COURSE");
                }
            }
            if (Input.GetTouch(i).position.x < screenHeight / 2)
            {
                //move left
                horizontal = -1;
                armatureComponent.armature.flipX = true;
                if (armatureComponent.animation.isPlaying && armatureComponent.animationName != "COURSE")
                {
                    armatureComponent.animationName = "COURSE";
                    armatureComponent.animation.Play("COURSE");
                }
            }

            if(Input.touchCount == 1)
            {
                Shoot();
            }
        }
       if(Input.GetKeyDown(KeyCode.Space))
       {
           Shoot();
       }
    }

    void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * speed, 0);
    }

    void Shoot()
    {
        Instantiate(PlayerLaser, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.rotation);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("ennemy") || collision.gameObject.layer == LayerMask.NameToLayer("DeadZone"))
        {
            restart.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
