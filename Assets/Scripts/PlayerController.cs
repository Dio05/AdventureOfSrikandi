using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float gerak;
    Vector2 arah;
    [SerializeField] float Kecepatan;
    [SerializeField] float Lompat;
    [SerializeField] bool ditanah;
    [SerializeField] bool tenggelam;
    Animator animasi;
    Rigidbody2D rb;
    [SerializeField] Transform BG;
    [SerializeField] float jumpingGravity = -9.81f;
    [SerializeField] float fallingGravity = -19.62f;

    AudioSource audioSource;
    [SerializeField] AudioClip[] audioClip;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animasi = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Physics2D.gravity = new Vector2(0, jumpingGravity);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        Facing();
        Moving();
    }

    void Movement()
    {
        //gerak kanan kiri
        gerak = Input.GetAxis("Horizontal");
        arah = new Vector2(gerak, 0);
        transform.Translate(arah * Time.deltaTime * Kecepatan);
    }

    void Moving()
    {
        animasi.SetFloat("Moving", Mathf.Abs(gerak));
        animasi.SetBool("OnGround", ditanah);
    }

    void Facing()
    {
        if (gerak < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            BG.localScale = new Vector3(-0.83344f, 1.634832f, 2.840521f);
        }
        if (gerak > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            BG.localScale = new Vector3(0.83344f, 1.634832f, 2.840521f);
        }
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && ditanah == true)
        {
            Physics2D.gravity = new Vector2(0, jumpingGravity);

            rb.velocity = new Vector2(0, Lompat);

            audioSource.clip = audioClip[0];
            audioSource.Play();

        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Physics2D.gravity = new Vector2(0, fallingGravity);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D pemain)
    {
        if (pemain.tag == "Tanah")
        {
            ditanah = true;
        }

        if (pemain.tag == "Water")
        {
            tenggelam = true;
            animasi.SetBool("Tenggelam", tenggelam);
            audioSource.clip = audioClip[1];
            audioSource.Play();
            Physics2D.gravity = new Vector2(0, 1);
        }
        
        if (pemain.tag == "home")
        {
            audioSource.enabled = false;
        }
        
    }


    private void OnTriggerExit2D(Collider2D pemain)
    {
        if (pemain.tag == "Tanah")
        {
            ditanah = false;
        }

        if (pemain.tag == "home")
        {
            audioSource.enabled = true;
        }
    }
}
