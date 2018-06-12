using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadSphere : MonoBehaviour
{

    [SerializeField] Transform laser;
    Vector2 shootDirection;
    Vector2 direction = new Vector2(0, -1);

    [SerializeField] Transform flameBall;
    [SerializeField] Transform stoneBall;
    [SerializeField] Sprite[] spriteArray;

    enum State
    {
        IDLE,
        LASER,
        FLAMES,
        STONE,
        LENGTH
    }
    State state = State.IDLE;

    void Start()
    {
        int spriteRandom = Random.Range(0, spriteArray.Length);
        this.GetComponent<SpriteRenderer>().sprite = spriteArray[spriteRandom];
    }

	void Update ()
    {
        shootDirection = transform.position - new Vector3(0,-1,0);
        //Debug.Log(state);
        switch (state)
        {
            case State.IDLE:
                break;

            case State.LASER:
                for(int i = -2; i <= 2;i++)
                {
                    LaserFire(Quaternion.AngleAxis(i * 15, new Vector3(0,0,1)) * direction.normalized);
                }
                Destroy(this.gameObject);
                break;

            case State.FLAMES:
                for(int i = 0; i <= 1; i++)
                {
                    flameFire(Quaternion.AngleAxis(i * Random.Range(0, 90), new Vector3(0, 0, 1)) * direction.normalized);
                }
                Destroy(this.gameObject);
                break;

            case State.STONE:
                StoneBall();
                Destroy(this.gameObject);
                break;
        }
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("PlayerLaser"))
        {
            state = (State)Random.Range(1, 4);
        }
    }

    void LaserFire(Vector2 Direction)
    {
        var laserShot = Instantiate(laser, transform.position, transform.rotation) as Transform;
        BadLaser shot = laserShot.gameObject.GetComponent<BadLaser>();
        shot.Direction = Direction.normalized;
    }

    void flameFire(Vector2 Direction)
    {
        var flameShot = Instantiate(flameBall, transform.position, transform.rotation) as Transform;
        FlamesBall shot = flameShot.gameObject.GetComponent<FlamesBall>();
        shot.Direction = Direction.normalized;
    }

    void StoneBall()
    {
        Instantiate(stoneBall,transform.position, transform.rotation);
    }
}
