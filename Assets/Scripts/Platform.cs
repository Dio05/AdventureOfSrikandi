using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] GameObject Player;
    BoxCollider2D colider;
    
    // Start is called before the first frame update
    void Start()
    {
        colider = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.y < transform.position.y)
        {
            colider.enabled = false;
            
        }
        
        if (Player.transform.position.y > transform.position.y)
        {
            colider.enabled = true;
           
        }
        
        if (Input.GetAxis("Vertical") < 0)
        {
            colider.enabled = false;
            
            
        }

       
    }
}
