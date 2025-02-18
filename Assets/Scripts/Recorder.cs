﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    [System.Serializable]
    public class WrappingClassTrack
    {
        public List<PointInTime> TrackMainCamera;
    }
    List<PointInTime> Track;
    // Start is called before the first frame update

    public bool save;
    public bool saveOnce;
    public string fileName = "TrackMainCamera";
    void Start()
    {
        Track = new List<PointInTime>();
        saveOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (save )
        {
            if (!saveOnce)
            {
                var variable = new WrappingClassTrack() { TrackMainCamera = Track };
                string debugTrack = JsonUtility.ToJson(variable);
                Debug.Log(debugTrack);
                string path = Application.persistentDataPath + "/" + fileName + System.DateTime.Now.ToString("yyyy''MM''dd'T'HH'mm'ss") + ".json";
                System.IO.File.WriteAllText(Application.persistentDataPath + "/MainCameraTrack.json", debugTrack);
                Debug.Log(Application.persistentDataPath + "/MainCameraTrack.json");
                saveOnce = true;
            }

        }
        else
        {
          var pointInTime = new PointInTime(Time.time, this.transform.position, this.transform.rotation);
          // string debugPointInTime = JsonUtility.ToJson(pointInTime);
          // Debug.Log(debugPointInTime);
          Track.Add(pointInTime);
            saveOnce = false;
        }
    }
}
