using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject _mainCamera;
    private Rigidbody2D playerRigidbody;
    public float moveSpeed = 200;
    Vector2 playerInput;
    private Ray mouseRay;
    private RaycastHit hit;
    private BoxCollider2D playerBoxCollider;
    public LayerMask jumpLayerMask;


    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerBoxCollider = transform.GetComponent<BoxCollider2D>();
        playerRigidbody.freezeRotation = true;
    }

    

    void FixedUpdate()
    {
        
        playerRigidbody.velocity = new Vector2(playerInput.x * Time.deltaTime * moveSpeed, playerRigidbody.velocity.y);
    }


    // Update is called once per frame
    void Update()
    {
        IsGrounded();
        Jump();
        playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
    }

    public void Jump()
    {
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, 20.0f);
        }
    }

    private bool IsGrounded()
    {
        float extraHeight = 1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(playerBoxCollider.bounds.center, Vector2.down, playerBoxCollider.bounds.extents.y + extraHeight, jumpLayerMask);
        Color rayColor;
        if(raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(playerBoxCollider.bounds.center, Vector2.down * (playerBoxCollider.bounds.extents.y + extraHeight),rayColor);
        return raycastHit.collider != null;

    
    }

}
