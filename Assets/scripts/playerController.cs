using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerController : MonoBehaviour
{

    public float maxSpeed = 10f;
    bool facingRight = true;
    Rigidbody2D rb;

    Animator aniM;

    bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 700f;


    //coins collect and count
    GameObject scores;

    GameObject winText;
    private int count;
    GameObject chest;
    Animator chestAnim;
   public Collider2D c1;
    
    GameObject deathScreen;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aniM = GetComponent<Animator>();
        scores = GameObject.Find("scores");
        count = 0;
        SetCountText();
        chest = GameObject.FindGameObjectWithTag("chest");
        chestAnim = chest.GetComponent<Animator>();

        winText = GameObject.FindGameObjectWithTag("win");
        winText.SetActive(false);

        deathScreen = GameObject.Find("death-screen");
        deathScreen.SetActive(false);

        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        aniM.SetBool("Ground", grounded);
        aniM.SetFloat("vSpeed", rb.velocity.y);



        // when jump - cant move
        if (!grounded) return;

        // moving character
        float move = Input.GetAxis("Horizontal");
        aniM.SetFloat("Speed", Mathf.Abs(move));
        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

        //flipping character
        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

    }


    void Update()
    {

        if (grounded && Input.GetKeyDown("space"))
        {
            aniM.SetBool("Ground", false);
            rb.AddForce(new Vector2(0f, jumpForce));
        }

    }


    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }



    void SetCountText()
    {



        scores.GetComponent<TextMesh>().text = count.ToString();


    }

    void OnTriggerEnter2D(Collider2D other)
    {
 Debug.Log(other.tag);
        if (other.gameObject.CompareTag("coins"))
        {

            other.gameObject.SetActive(false);
            count++;
            SetCountText();


        }
        if (other.gameObject.CompareTag("chest"))
        {
            chestAnim.SetBool("touched", true);
            winText.SetActive(true);

        }
        if (other.gameObject.CompareTag("enemy"))
        {
           
            rb.AddForce(new Vector2(0f, 150f));
            StartCoroutine (processTask());

        }
        if(other.gameObject.CompareTag("botline")){
            deathScreen.SetActive(true);
            Destroy(gameObject);
        }
    }

    IEnumerator processTask()
    {
        yield return new WaitForSeconds(0.15f);
        c1.enabled = false;
        
    }



}