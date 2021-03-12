using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnButtonPressEnd : MonoBehaviour
{
    public bool EndGame = false;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Button")
        {
            //TurnNested.SetActive(false);
            EndGame = true;


        }
    }
}
