using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    Rigidbody2D rb;
    CapsuleCollider2D capsCol;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsCol = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move()
    {
        float deltaX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(deltaX * speed, rb.velocity.y);
    }

    public void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.UpArrow)) && capsCol.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }
        
    }
}
