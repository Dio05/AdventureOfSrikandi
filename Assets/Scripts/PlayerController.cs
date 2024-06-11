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
    Animator animasi;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animasi = GetComponent<Animator>();
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
        }
        if (gerak > 0.1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ditanah == true)
        {
            rb.velocity = new Vector2(0, Lompat);
        }
    }

    private void OnTriggerEnter2D(Collider2D pemain)
    {
        if (pemain.tag == "Tanah")
        {
            ditanah = true;
        }
    }


    private void OnTriggerExit2D(Collider2D pemain)
    {
        if (pemain.tag == "Tanah")
        {
            ditanah = false;
        }
    }
}
