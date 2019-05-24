using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{

    public float speed;
    public float rotationSpeed;
    public Text countText;
    public Text winText;

    private Vector2 moveVelocity;
    private Rigidbody2D rb2d;
    private int count;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        SetCountText();
    }
     void Update()
    {
        float rotateInput = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0, 0, - rotateInput * rotationSpeed);

        Vector2 moveInput = Vector2.up * Input.GetAxisRaw("Vertical");
        moveVelocity = speed * ( transform.rotation * moveInput);
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


    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count>= 27)
        {
            {
                SceneManager.LoadScene("Win_screen");
            }

        if (Health <= 0)
        {
                SceneManager.LoadScene("lose_screen");
        }

            winText.text = "You Win";
        }
    }
}