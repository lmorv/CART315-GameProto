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
        LevelController.instance.AddDestructable();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 17.5f && !canBeDestroyed)
        {
            canBeDestroyed = true;
            GunScript[] guns = transform.GetComponentsInChildren<GunScript>();
            foreach (GunScript gun in guns)
            {
                gun.isActive = true;
            }
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
            if (!bullet.isEnemy)
            {
                Destroy(gameObject);
                Destroy(bullet.gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        LevelController.instance.RemoveDestructable();
    }
}
