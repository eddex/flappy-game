using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField]
    private float UpForce = 200f;

    private bool birdDead = false;
    private Rigidbody2D birdRigidbody;
    private Animator birdAnimator;
    
    // Use this for initialization
	void Start ()
    {
        this.birdRigidbody = GetComponent<Rigidbody2D>();
        this.birdAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!this.birdDead)
        {
            if (Input.GetMouseButtonDown (0))
            {
                this.birdRigidbody.velocity = Vector2.zero;
                this.birdRigidbody.AddForce(new Vector2(0, this.UpForce));
                this.birdAnimator.SetTrigger("Flap");
            }
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!this.birdDead)
        {
            this.birdRigidbody.velocity = Vector2.zero;
            this.birdDead = true;
            this.birdAnimator.SetTrigger("Die");
            GameControl.Instance.BirdDied();
        }
    }
}
