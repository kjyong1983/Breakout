using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    float x, y;
    [SerializeField] float dx, dy;
    [SerializeField] float modifier;
    const float minSpeed = 3f;
    const float maxSpeed = 15f;

    [SerializeField] float angle;

    float distance;
    bool hitByPlayer = false;
    bool isReduced = false;

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


        if (distance < 2f && !hitByPlayer && !isReduced)
        {
            isReduced = true;
            dx = Mathf.Sign(dx) * minSpeed * modifier;
            dy = Mathf.Sign(dy) * minSpeed;
        }

        rb.velocity = new Vector2(dx, dy);
        angle = Vector2.Angle(Vector2.zero, new Vector2(dx, dy));

        Debug.Log("dx " + dx + " dy " + dy);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var distance = transform.position.x - player.transform.position.x;

            modifier = distance / (player.transform.lossyScale.x / 2);
            
            dx *= maxSpeed * modifier;
            dy *= -maxSpeed;

            hitByPlayer = true;
            isReduced = false;

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
        else if (collision.gameObject.CompareTag("Block"))
        {
            dy *= -1;
        }
        else//left, right wall
        {
            dx *= -1;
        }

    }
}
