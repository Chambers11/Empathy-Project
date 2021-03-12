using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOnPress : MonoBehaviour
{
    public GameObject AniButton;
    public GameObject StaticButton;

    // Start is called before the first frame update


    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hand")
        {
            //TurnNested.SetActive(false);
            AniButton.SetActive(true);
            StaticButton.SetActive(false);

        }
    }
    
}
