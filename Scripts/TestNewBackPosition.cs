using Academy.HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNewBackPosition : MonoBehaviour {

    GameObject com1, com2;
    bool Finish = false;

	// Use this for initialization
	void Start ()
    {
        com1 = GameObject.FindGameObjectWithTag("TrafficCone");
        com2 = GameObject.FindGameObjectWithTag("Panel");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Finish == false)
        {
            Debug.Log("GazePosition: " + GazeManager.Instance.HitInfo.point);
            Debug.Log("Object Position: " + this.gameObject.transform.position);
            Debug.Log("TrafficPositon: " + com1.transform.position);
            Debug.Log("PanelPositon: " + com2.transform.position);

            Finish = true;
        }
      
    }

}
