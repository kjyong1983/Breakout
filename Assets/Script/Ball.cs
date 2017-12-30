﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    float x, y;
    [SerializeField] float dx, dy;
    const float minSpeed = 2f;
    const float maxSpeed = 10f;

    float distance;
    bool hitByPlayer = false;

    Rigidbody2D rb;
    GameObject player;

	// Use this for initialization
	void Start () {
        dx = Random.Range(-1f, 1f);
        dy = -1 * minSpeed;

        player = GameObject.FindGameObjectWithTag("Player");

        Debug.Log("dx = " + dx);

        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        distance = Mathf.Abs(player.transform.position.y - gameObject.transform.position.y);


        if (distance < 1f && !hitByPlayer)
        {
            Debug.Log("distance = " + distance);

            //rb.velocity = rb.velocity.normalized;
            //rb.velocity.Normalize();
            dx = Mathf.Sign(dx) * minSpeed;
            dy = Mathf.Sign(dy) * minSpeed;
        }

        //if (dy > 20)
        //{
        //    dy = Mathf.Sign(dy) * minSpeed;
        //    //Debug.Break();
        //}
        rb.velocity = new Vector2(dx, dy);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dx *= maxSpeed;
            dy *= -maxSpeed;

            hitByPlayer = true;

        }
        else if (collision.gameObject.CompareTag("SafeWall"))
        {
            dy *= -1;
            hitByPlayer = false;
        }
        else if (collision.gameObject.CompareTag("Wall"))//wall at bottom
        {
            dy *= -minSpeed * Mathf.Sign( rb.velocity.y);
            hitByPlayer = false;
            
        }
        else//left, right wall
        {
            dx *= -1;
            hitByPlayer = false;
        }
    }
}
