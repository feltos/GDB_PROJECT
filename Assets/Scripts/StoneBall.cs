using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBall : MonoBehaviour
{
	void Start ()
    {
        Input.gyro.enabled = true;
	}
	
	void Update ()
    {
        if(Input.gyro.gravity.x >= 0.4 || Input.gyro.gravity.x <= -0.4)
        {
            Debug.Log("moved");
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Debug.Log("collide");
            Destroy(collider.gameObject);
        }
    }
}
