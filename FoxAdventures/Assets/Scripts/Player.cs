using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocity;
    public float push;
    public GameObject sensorFloor;

    private bool jump;
    private bool isOnFloor;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal") * velocity * Time.deltaTime;
        transform.Translate(move, 0.0f, 0.0f);

        isOnFloor = Physics2D.Linecast(transform.position,
            sensorFloor.transform.position, 1 << LayerMask.NameToLayer("Floor"));

        //verify jump
        if (Input.GetButtonDown("Jump") && isOnFloor)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        //jump
        if (jump)
        {
            rb.AddForce(Vector2.up * push);
            jump = false;
        }
    }
}
