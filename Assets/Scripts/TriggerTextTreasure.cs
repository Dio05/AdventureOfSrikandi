using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTextTreasure : MonoBehaviour
{
    [SerializeField] GameObject textObjek;
    AudioSource textSource;

    private void Start()
    {
        textSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            textObjek.SetActive(true);
            textSource.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            textObjek.SetActive(false);
        }
    }

    public void hancur()
    {
        Destroy(this.gameObject);
    }
}
