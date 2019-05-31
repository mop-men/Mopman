using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float rotationSpeed;
    public Text countText;
    public Text winText;

    public Text HealthText;
    public Text LoseText;

    private Vector2 moveVelocity;
    private Rigidbody2D rb2d;
    private int count;
    private int Health;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        SetCountText();
        Health = 3;
        SetHealthText();
    }


    void Update()
    {
        float rotateInput = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0, 0, -rotateInput * rotationSpeed);

        Vector2 moveInput = Vector2.up * Input.GetAxisRaw("Vertical");
        moveVelocity = speed * (transform.rotation * moveInput);
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + moveVelocity * Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Damage"))
        {

            Health = Health - 1;
            SetHealthText();
        }
    }

    void SetHealthText()
    {
        HealthText.text = "health:" + Health.ToString();
        if (Health <= 0)
        {
            LoseText.text = "You Have Lost";
        }
    }
       
    void SetCountText()
    {
        countText.text = "Rubbish Cleaned: " + count.ToString();
        if(count>= 27)
        {
            winText.text = "You Win";
        }
    }
}