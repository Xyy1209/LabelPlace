using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class Selected : MonoBehaviour {

    public GameObject Prefab;
    public bool Place = true;
    //判断是否实例化Back标签
    public bool BackDone = false;
    public static Selected Instance;

    void Start()
    {
        Selected Instance = this;
    }
    void Instantiate()
    {
        if (Place)
        {
            GameObject obj = Instantiate(Prefab) as GameObject;
            Prefab.transform.position=GazeManager.Instance.HitInfo.point;
            //Debug.LogFormat(@"Name: {0}  Psotion: {1}  Normal: {2}  ", obj.name, GazeManager.Instance.HitPosition, GazeManager.Instance.HitNormal);
            //print("Position: " + GazeManager.Instance.HitPosition);
            //print("Normal: " + GazeManager.Instance.HitNormal);
        
            Debug.LogFormat(@"Name: {0}  GazePosition: {1}  ObjectPosition: {2}", obj.name, GazeManager.Instance.HitPosition, obj.transform.position);

            if(obj.name.Contains("Back"))
            {
                BackDone = true;
                Debug.Log("Back is done.");
            }
            else
            {
                BackDone = false;
            }

            Place = !Place;
        }
    }


}
