using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
 


public class PP : MonoBehaviour
{
    public GameObject startPlayMenu;
    public GameObject play;
    public GameObject pause; 

    public static bool GameIsPaused = false;
    // Start is called before the first frame update


    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Pause();
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Play();
        }
    }


    public void Pause()
    {

        
        { 
            GameManager.isGameStarted = true;
            GameIsPaused = true;
            Time.timeScale = 0;
            startPlayMenu.SetActive(true);
            play.SetActive(true);
            pause.SetActive(false);
        }
    }

        public void Play()
        {
             if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Time.timeScale = 1;
                startPlayMenu.SetActive(false);
                play.SetActive(false);
                pause.SetActive(true);

             }
        }
    }
