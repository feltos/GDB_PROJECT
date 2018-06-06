using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadSphere : MonoBehaviour
{

    [SerializeField] Transform Laser;
    Vector2 shootDirection;
    Vector2 direction = new Vector2(0, -1);

    enum State
    {
        IDLE,
        LASER,
        FLAMES,
        STONE
    }
    State state = State.IDLE;

	void Update ()
    {
        shootDirection = transform.position - new Vector3(0,-1,0);
        Debug.Log(state);
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
                break;

            case State.STONE:
                break;
        }
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == LayerMask.NameToLayer("PlayerLaser"))
        {
            state = State.LASER;
        }
    }

    void LaserFire(Vector2 Direction)
    {
        var laserShot = Instantiate(Laser, transform.position, transform.rotation) as Transform;
        BadLaser shot = laserShot.gameObject.GetComponent<BadLaser>();
        shot.Direction = Direction.normalized;
    }
}
