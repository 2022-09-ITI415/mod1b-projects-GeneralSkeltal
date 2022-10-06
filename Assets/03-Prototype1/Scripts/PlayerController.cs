using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jumpForce = 5f;

    public TextMeshProUGUI countText;
    public TextMeshProUGUI winText;

    public LayerMask groundLayer;
    private Rigidbody rb;
    private int count;

    public bool isGrounded;
    Vector3 startPos;
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winText.text = "";
        startPos = transform.position;
    }

    private void Update()
    {
        HandleJump();
    }
    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);       
    }
    void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag("Pick Up"))
        //{
        //    other.gameObject.SetActive(false);
        //    count = count + 1;
        //    SetCountText ();
        //}
    }

    public void OnCollisionEnter(Collision collision)
    {  
        if (collision.gameObject.GetComponent<DeathGround>())
        {
            transform.position = startPos;
        }
    }
    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if(count >= 12)
        {
            winText.text = "You Win";
        }
    }

    void GroundCheck()
    {
        float distToBound = GetComponent<SphereCollider>().bounds.extents.y;
        RaycastHit hit;
        Vector3 raycastOrigin = transform.position;
        Debug.DrawRay(raycastOrigin, Vector3.down, Color.red);
        if (Physics.Raycast(raycastOrigin, Vector3.down, distToBound + 0.5f, groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

    }

    void HandleJump()
    {
        GroundCheck();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
