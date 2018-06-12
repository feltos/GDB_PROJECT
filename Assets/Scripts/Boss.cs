using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Boss : MonoBehaviour
{
    Rigidbody2D body;
    Vector2 target;
    [SerializeField] float speed;
    int rand;
    Vector3 newPosition;
    [SerializeField] GameObject restart;

    enum State
    {
        IDLE,
        ATTACK,
        MOVE,
        LENGTH
    }
    State state = State.IDLE;

	void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        restart.SetActive(false);
        Time.timeScale = 1;
	}
	
	void Update ()
    {
        Debug.Log(state);
		switch(state)
        {
            case State.IDLE:
                rand = Random.Range(-2, 2);
                newPosition = new Vector3(rand, transform.position.y, transform.position.z);
                state = State.MOVE;
                break;
            case State.ATTACK:
                break;
            case State.MOVE:
                transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * speed);
  
                if(Vector3.Distance(transform.position, newPosition ) <= 0.01f )
                {
                    state = State.IDLE;
                }
                break;
        }

	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("PlayerLaser"))
        {
            restart.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("Triggered");
        }
    }
}
