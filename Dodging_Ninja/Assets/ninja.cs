using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class ninja : MonoBehaviour
{
    public float speed;
    public float jump;
    public Animator animation;
    int hits = 0;

    public Image health;
    float full_healt = 100.0f;
    float current_healt = 100.0f;
    bool game_lost = false;

    TextMeshProUGUI hit_txt;
    TextMeshProUGUI goal_txt;

    public GameObject endscreen_win;
    public GameObject endscreen_lose;
    public float timer = 60.0f;

    private bool isGrounded;

    private void Start()
    {
        hit_txt = GameObject.Find("Canvas/hit_txt").GetComponent<TextMeshProUGUI>();
        goal_txt = GameObject.Find("Canvas/goal_txt").GetComponent<TextMeshProUGUI>();
        InvokeRepeating("timee", 0.0f, 1.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="shuriken")
        {
            hits++;
            hit_txt.text = hits.ToString();

            current_healt -= 33.4f;
            health.fillAmount = current_healt / full_healt;
        }
    }

    void timee()
    {
        timer--;

        if (timer == 0)
        {
            if (game_lost == true)
            {
                endscreen_lose.SetActive(true);

            }
            else
            {
                endscreen_win.SetActive(true);

            }
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            //        if (Input.GetKeyDown(KeyCode.UpArrow))
            //        {
            //          // transform.Translate(0, jump * Time.deltaTime, 0);  //jump
            //           GetComponent<Rigidbody>().AddForce(Vector3.up * jump * Time.deltaTime);

            //            animation.SetTrigger("jujump");
            isGrounded = true;

        }


        //    }
    }

    void Update()
    {
        
      
        if(hits >= 3)
        {
            game_lost = true;
            goal_txt.text = "failed";
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
             animation.SetTrigger("run");              //running animation
;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
             animation.SetTrigger("run");

        }

        float horizontal = Input.GetAxis("Horizontal");

        if(horizontal == 0)                       //idle animation
        {
            animation.SetTrigger("stop");
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {
            isGrounded = false;
            //  Mathf.Lerp(transform.position, transform.Translate(0, jump * Time.deltaTime, 0), Time.deltaTime * 5f);          
             transform.Translate(0, jump * Time.deltaTime, 0);  //jump
            //GetComponent<Rigidbody>().AddForce(Vector3.up * jump * Time.deltaTime);

            animation.SetTrigger("jujump");

        }

    }

    private void FixedUpdate() //movement
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.RightArrow))        //go right
        {
             GetComponent<Rigidbody>().velocity = Vector3.right * speed * Time.deltaTime;
           // transform.Translate(Vector3.forward * speed * horizontal * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))         //go left
        {
            GetComponent<Rigidbody>().velocity = Vector3.left * speed * Time.deltaTime;
                  //    transform.Translate(-Vector3.forward * speed * horizontal * Time.deltaTime);


        }


        //if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        //{
        //    isGrounded = false;           
        //    //  Mathf.Lerp(transform.position, transform.Translate(0, jump * Time.deltaTime, 0), Time.deltaTime * 5f);          
        //    // transform.Translate(0, jump * Time.deltaTime, 0);  //jump
        //    GetComponent<Rigidbody>().AddForce(Vector3.up * jump * Time.deltaTime);

        //    animation.SetTrigger("jujump");
            
        //}
    }

    /* void OnCollisionEnter (Collision collision)
      {
          if(collision.gameObject.name == "Plane")
          {
              if (Input.GetKeyDown(KeyCode.UpArrow))
              {
                  Vector3 vertical = new Vector3(0f, 1f, 0f);
                  transform.position += jump * vertical * Time.deltaTime;
              }
          }
      } */


}
