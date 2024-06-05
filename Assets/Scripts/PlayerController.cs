using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 10f;
    private bool isGrounded;
    public Transform cameraTransform;  // Kameranın Transform bileşeni

    private Rigidbody rb;
    private float xInput;
    private float zInput;
    public int score = 0;
    public int winScore;
    public GameObject winText;
    public AudioSource jumpSound;
    public AudioSource coinSound;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position.y < -5f)
        {
            SceneManager.LoadScene("Game");
        }

        // Jump logic
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            jumpSound.Play();
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        // Kameranın yöne göre hareketi hesaplama
        Vector3 direction = new Vector3(xInput, 0, zInput).normalized;
        if (direction.magnitude >= 0.1f)
        {
            // Kameranın yönüne göre hareket yönünü hesapla
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            rb.AddForce(moveDirection * speed, ForceMode.Force);
        }
    }

    // Check if the ball is on the ground
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coinSound.Play();
            other.gameObject.SetActive(false);
            score++;
            if (score >= winScore)
            {
                //gamewin
                winText.SetActive(true);
            }
        }
    }
}