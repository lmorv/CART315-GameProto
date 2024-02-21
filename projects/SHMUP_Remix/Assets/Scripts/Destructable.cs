using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    private bool canBeDestroyed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 12.5f)
        {
            canBeDestroyed = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canBeDestroyed)
        {
            return;
        }
        
        BulletScript bullet = collision.GetComponent<BulletScript>();
        if (bullet != null)
        {
            Debug.Log("HIT!");
            Destroy(gameObject);
            Destroy(bullet.gameObject);
        }
    }
}
