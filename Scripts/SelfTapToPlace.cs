using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;


public class SelfTapToPlace : MonoBehaviour,IInputClickHandler{

    public GameObject Prefab;

    //public GameObject Prefab;
    // Use this for initialization
    void Start()
    {
        InputManager.Instance.PushModalInputHandler(this.gameObject);
    }

    public void OnInputClicked(InputClickedEventData eventData)
     {
         GameObject Collection = Instantiate(Prefab) as GameObject;
         this.gameObject. transform.position = GazeManager.Instance.HitPosition;
         print("Position: " + GazeManager.Instance.HitPosition);
         print("Normal: " + GazeManager.Instance.HitNormal);
  
     }



}
