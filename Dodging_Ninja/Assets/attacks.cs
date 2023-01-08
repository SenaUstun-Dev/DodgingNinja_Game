using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class attacks : MonoBehaviour
{
    public int difficulty;
    public GameObject shuriken;
    public GameObject again_button;
    

    TextMeshProUGUI timer_txt;

    public Transform shuriken_L_U;
    public Transform shuriken_L_M;
    public Transform shuriken_L_D;
    public Transform shuriken_R_U;
    public Transform shuriken_R_M;
    public Transform shuriken_R_D;

    public float timer = 60.0f;
    bool paused = false;
  

    private void Start()
    {
        InvokeRepeating("shurikenSpawn", 2.0f,3.0f);       
        InvokeRepeating("time", 0.0f, 1.0f);
               
        timer_txt = GameObject.Find("Canvas/timer_txt").GetComponent<TextMeshProUGUI>();
    }

    public void play_again()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
        Time.timeScale = 1.0f;
    }

    public void pause()
    {
        paused = !paused;
        if(paused == true)
        {
            Time.timeScale = 0.0f;
            again_button.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            again_button.SetActive(false);

        }
    }

    void shurikenSpawn()
    {
        if (Random.Range(0, difficulty) == 1)
        {
            Instantiate(shuriken, shuriken_L_U.position, Quaternion.identity);
        }

        if (Random.Range(0, difficulty) == 1)
        {
            Instantiate(shuriken, shuriken_L_M.position, Quaternion.identity);
        }

        if (Random.Range(0, difficulty) == 1)
        {
            Instantiate(shuriken, shuriken_L_D.position, Quaternion.identity);
        }

        if (Random.Range(0, difficulty) == 1)
        {
            Instantiate(shuriken, shuriken_R_U.position, Quaternion.identity);
        }

        if (Random.Range(0, difficulty) == 1)
        {
            Instantiate(shuriken, shuriken_R_M.position, Quaternion.identity);
        }

        if (Random.Range(0, difficulty) == 1)
        {
            Instantiate(shuriken, shuriken_R_D.position, Quaternion.identity);
        }
  
    }

    void time()
    {
        timer--;
        timer_txt.text = timer.ToString();

        if (timer == 0)
        {
            Time.timeScale = 0;
            CancelInvoke("shurikenSpawn");
            CancelInvoke("time");
        }

    }

}
