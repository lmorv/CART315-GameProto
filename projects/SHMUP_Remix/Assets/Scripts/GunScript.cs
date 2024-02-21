using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public BulletScript bullet;
    private Vector2 direction;
    
    public bool autoShoot = false;
    public float shootIntervalSeconds = 0.5f;
    public float shootDelaySeconds = 0.0f;
    private float shootTimer = 0.0f;
    private float delayTimer = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        direction = (transform.localRotation * Vector2.right).normalized;
        
        if (autoShoot)
        {
            if (delayTimer >= shootDelaySeconds)
            {
                if (shootTimer >= shootIntervalSeconds)
                {
                    Debug.Log("shoosthing");
                    Shoot();
                    shootTimer = 0;
                }
                else
                {
                    shootTimer += Time.deltaTime;
                }
            }
            else
            {
                delayTimer += Time.deltaTime;
            }
        }
    }

    public void Shoot()
    {
        GameObject go = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        BulletScript goBullet = go.GetComponent<BulletScript>();
        goBullet.direction = direction;
    }
}

