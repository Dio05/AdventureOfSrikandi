using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPoly : MonoBehaviour
{
    [SerializeField] GameObject Player;
    PolygonCollider2D polycol;
    // Start is called before the first frame update
    void Start()
    {
        
        polycol = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.y < transform.position.y)
        {
            
            polycol.enabled = false;
        }
        
        if (Player.transform.position.y > transform.position.y)
        {
            
            polycol.enabled = true;
        }
        
        if (Input.GetAxis("Vertical") < 0)
        {
            
            polycol.enabled = false;
            
        }

       
    }
}
