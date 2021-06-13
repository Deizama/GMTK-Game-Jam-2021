using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Human : MonoBehaviour
{
    public Transform humanBody;
    public Transform ghostBody;
    Rigidbody2D rb;
    public float Speed;
    public bool IsGrounded;
    public float JumpForce;
    public GameObject FootR;
    public GameObject FootL;
    private float x;

    public int health = 3;
    private DistanceJoint2D joint;

    public Transform checkpoint;
    private Animator animator;

    public Image Coeur1;
    public Image Coeur2;
    public Image Coeur3;

    private bool isInvincible = false;

    private AudioSource audioSource;
    public AudioClip hurtSound;
    public AudioClip jumpSound;
    public AudioClip buttonPressedSound;
    public AudioClip tetherSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.AddForce(Vector2.up * JumpForce);
            audioSource.PlayOneShot(jumpSound);
        }

        x = Input.GetAxis("Horizontal") * Speed * 0.1f;

        if (Input.GetMouseButtonDown(0))
        {
            audioSource.PlayOneShot(tetherSound);
        }
    }

    void FixedUpdate()
    {

        //Walk
        //float x = Input.GetAxis("Horizontal") * Speed * 0.1f;
        humanBody.Translate(Vector3.right * x);

        //Animation
        if (x > 0.01f)
        {
            animator.SetBool("WalkR", true);
            animator.SetBool("WalkL", false);
        }
        else if (x < -0.01f)
        {
            animator.SetBool("WalkL", true);
            animator.SetBool("WalkR", false);
        }
        else if (x < 0.01f && x > -0.01f)
        {
            animator.SetBool("WalkL", false);
            animator.SetBool("WalkR", false);
        }


        humanBody.Translate(Vector3.right * x);

        //Jump
        RaycastHit2D hitL = Physics2D.Raycast(FootL.transform.position, -Vector2.up, 0.2f);
        RaycastHit2D hitR = Physics2D.Raycast(FootR.transform.position, -Vector2.up, 0.2f);

        if (hitL || hitR)
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }

    }

    public void LosingHealth(int damage)
    {
        if (!isInvincible)
        {
            if (damage > 0)
            {
                health = health - damage;
                audioSource.PlayOneShot(hurtSound);
                Debug.Log("Damage : " + damage);
                Debug.Log("health : " + health);
                
                StartCoroutine(Invincibility());
            }
        }

        if (health <= 0)
        {
            health = 3;
            humanBody.position = checkpoint.position;
            Coeur2.gameObject.SetActive(true);
            Coeur3.gameObject.SetActive(true);
        }
        else if (health == 1)
        {
            Coeur2.gameObject.SetActive(false);
            Coeur3.gameObject.SetActive(false);
        }
        else if (health == 2)
        {
            Coeur3.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // layer 10 = checkpoint
        if (collision.gameObject.layer == 10)
        {
            checkpoint = collision.transform;
        }

        // layer 12 = button
        if (collision.gameObject.layer == 12)
        {
            audioSource.PlayOneShot(buttonPressedSound);
        }
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // layer 11 = Slimes
        if (collision.gameObject.layer == 11)
        {
            this.LosingHealth(1);
        }
    }*/

    private IEnumerator Invincibility()
    {
        isInvincible = true;
        Debug.Log("Invincible");

        yield return new WaitForSeconds(1);

        isInvincible = false;
        Debug.Log("!Invincible");
    }
}