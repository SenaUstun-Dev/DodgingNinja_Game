using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public float speedd;
    public float jumpp;
    RaycastHit nesne;

    private void Update()
    {
        if (Physics.Raycast(transform.position, -transform.up, out nesne, 1.0f))
            {
                if (nesne.collider.gameObject.tag == "floor")
                {
                    if (Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        //  Mathf.Lerp(transform.position, transform.Translate(0, jump * Time.deltaTime, 0), Time.deltaTime * 5f);
                        transform.Translate(0, jumpp * Time.deltaTime, 0);  //jump
                        // GetComponent<Rigidbody>().AddForce(Vector3.up * jump * Time.deltaTime);
                    }
                }
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag == "floor")
    //    {
    //        if (Input.GetKeyDown(KeyCode.UpArrow))
    //        {
    //            transform.Translate(0, jumpp * Time.deltaTime, 0);  //jump
    //                                                                //  GetComponent<Rigidbody>().AddForce(Vector3.up * jump * Time.deltaTime);
    //        }


    //    }
    //}


    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))        //go right
        {
            GetComponent<Rigidbody>().velocity = Vector3.right * speedd * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))         //go left
        {
            GetComponent<Rigidbody>().velocity = Vector3.left * speedd * Time.deltaTime;

        }

    }
}
