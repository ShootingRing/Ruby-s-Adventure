using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2.0f;

    float horizental;
    float vertical;

    Rigidbody2D rigidbody2D;

    float verticalMoveTime = 4.0f;
    float verticalTimer;

    void Start()
    {
        verticalTimer = verticalMoveTime / 2;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizental = 0;

        if(verticalTimer > -verticalMoveTime)
        {
            verticalTimer -= Time.deltaTime;
        }
        else
        {
            verticalTimer = verticalMoveTime;
        }

        vertical = verticalTimer>0?1:-1;

    }

    private void FixedUpdate()
    {

        Vector2 position = rigidbody2D.position;

        position.x += horizental * speed * Time.deltaTime;
        position.y += vertical * speed * Time.deltaTime;

        rigidbody2D.MovePosition(position);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
}
