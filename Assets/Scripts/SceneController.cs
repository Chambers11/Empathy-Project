using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public Survey survey2Finished;                                                 //reference to surveyController script

    public GameObject XRRig, XRRig3, wheelChair, environment, video1Sphere, video2Sphere, survey1Canvas, survey2Canvas, welcomeCanvas, finishCanvas;      //creates refeences for gameobjects
    public VideoPlayer VRVideo1, VRVideo2;                                                  //creates references for video player
    public bool survey1Complete, survey2Complete, environmentComplete, restart, close, Vid2Played;                                           //bools to control
    public Button next, replay, finish;
    public GameObject ButtonEnd;



    void Start()
    {
        VRVideo1.Stop();                                        //ensures video not playing
        VRVideo2.Stop();                                        //ensures video is not playing
        video1Sphere.SetActive(false);                           //ensures game object inactive
        video2Sphere.SetActive(false);                           //ensures game object inactive
        wheelChair.SetActive(false);                            //ensures gameobject is inactive
        environment.SetActive(false);                           //ensures gameobject is inactive
        welcomeCanvas.SetActive(true);
        survey1Canvas.SetActive(false);                          //sets this game object to active
        survey2Canvas.SetActive(false);                         //sets this game object to inactive
        finishCanvas.SetActive(false);
        XRRig.SetActive(true);
        XRRig3.SetActive(false);
        Vid2Played = false;


    }

    // Update is called once per frame
    void Update()
    {

        if (ButtonEnd.activeSelf == true)
        {
            environmentComplete = true;
        }
        next.onClick.AddListener(LaunchSurvey1);
        replay.onClick.AddListener(RestartBtn);
        finish.onClick.AddListener(Finish);

        if (VRVideo1.isPlaying != true && survey1Complete == true && survey2Finished.postSurveyComplete == false)      //if the video has finished playing and survey is completed....
        {
            LaunchEnvironment();                                        //call funstion
        }
        if (environmentComplete && survey2Finished.postSurveyComplete == false)
        {
            LaunchSurvey2();
        }
        if (environmentComplete == true && survey2Finished.postSurveyComplete == true && Vid2Played == false)
        {
            LaunchVideo2();
        }
        if (VRVideo2.isPlaying != true && survey2Finished.postSurveyComplete == true && Vid2Played == true)
        {
            LaunchFinishCanvas();
        }
        if (restart)
        {
            Replay();
        }
        if (close)
        {
            //UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }

    }

    void LaunchSurvey1()
    {
        welcomeCanvas.SetActive(false);
        survey1Canvas.SetActive(true);
        XRRig.SetActive(true);

    }

    public void LaunchVideo1()
    {
        video1Sphere.SetActive(true);                            //set gameobject to active
        VRVideo1.Play();                                        //play video file
        survey1Canvas.SetActive(false);                          //turn off survey canvas
        survey1Complete = true;                                 //set bool to true
        XRRig.SetActive(true);

    }

    void LaunchEnvironment()
    {
        video1Sphere.SetActive(false);                   //deactivates gameobject
        wheelChair.SetActive(true);                     //activate gameobject
        environment.SetActive(true);                    //activate gameobject
        XRRig.SetActive(false);

    }

    void LaunchSurvey2()
    {
        wheelChair.SetActive(false);                    //ensures gameobject is inactive
        environment.SetActive(false);                   //ensures gameobject is inactive
        survey2Canvas.SetActive(true);                   //sets this game object to active
        XRRig3.SetActive(true);
        survey2Complete = true;

    }

    public void LaunchVideo2()
    {
        survey2Canvas.SetActive(false);                  //turn off survey canvas
        video2Sphere.SetActive(true);                    //set gameobject to active
        VRVideo2.Play();                                //play video file
        XRRig3.SetActive(true);
        Vid2Played = true;



    }

    void LaunchFinishCanvas()
    {
        video2Sphere.SetActive(false);
        finishCanvas.SetActive(true);
        XRRig3.SetActive(true);

    }

    void RestartBtn()
    {
        restart = true;
    }

    void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Finish()
    {
        close = true;
    }
}
