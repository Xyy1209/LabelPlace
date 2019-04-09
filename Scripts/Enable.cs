using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable : MonoBehaviour {


    public static  bool SpeakOnEnable = true;


    private void OnEnable()
    {
        this.gameObject.GetComponentInChildren<AudioSource>().clip = null;
    }


    // Update is called once per frame
    void Update ()
    {
     	
	}


}
