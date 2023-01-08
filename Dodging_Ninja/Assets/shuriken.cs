using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class shuriken : MonoBehaviour
{
  
    public int speed;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "left")
        {
            GetComponent<Rigidbody>().velocity = (transform.right * speed * Time.deltaTime);
        }

        if (other.gameObject.name == "right")
        {
            GetComponent<Rigidbody>().velocity = (-transform.right * speed * Time.deltaTime);
        }

        if (other.gameObject.name == "Player")
        {         
            Destroy(gameObject);
        }
        Destroy(gameObject, 4.0f);
    }


}
