using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D groundRigidbody;

	void Start ()
    {
        this.groundRigidbody = GetComponent<Rigidbody2D>();
        this.groundRigidbody.velocity = new Vector2(GameControl.Instance.ScrollSpeed, 0);
		
	}
	
	void Update ()
    {
        if (GameControl.Instance.GameOver)
        {
            this.groundRigidbody.velocity = Vector2.zero;
        }		
	}
}
