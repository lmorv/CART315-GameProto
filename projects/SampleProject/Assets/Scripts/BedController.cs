using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BedController : MonoBehaviour
{
    private SpriteRenderer sr;

    public float xLoc = 0;

    public float bedSpeed = .1f;
    
    public float rotationSpeed = 5f;

    public float score = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        sr.color = Color.gray;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            xLoc -= bedSpeed;
            sr.flipX = true;
            
        }
        
        if (Input.GetKey(KeyCode.X))
        {
            xLoc += bedSpeed;
            sr.flipX = false;
          
        }

        this.transform.position = new Vector3(xLoc, transform.position.y, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Sleepy") score += 1;
        else score -= 1;
        
        Destroy(other.gameObject);
    }
    
    void RotateBed()
    {
        // Rotate the bed slightly on the Z-axis
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
