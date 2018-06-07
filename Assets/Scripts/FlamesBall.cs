using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamesBall : MonoBehaviour
{

    [SerializeField] float speed;
    Vector2 movement;
    Vector2 direction = new Vector2(0, -1);
    Rigidbody2D body;
    [SerializeField] GameObject flamesZone;

    public Vector2 Direction
    {
        get
        {
            return direction;
        }

        set
        {
            direction = value;
        }
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement = new Vector2(
            speed * Direction.x,
            speed * Direction.y);
    }

    void FixedUpdate()
    {
        body.velocity = movement;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            direction = new Vector2(-direction.x, direction.y);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            for(int i = 0; i <= 1; i++)
            FlamesZone();
        }
    }

    void FlamesZone()
    {
        this.gameObject.SetActive(false);
        GameObject flame = Instantiate(flamesZone, transform.position, transform.rotation);
        Destroy(flame, 3);
    }
}
