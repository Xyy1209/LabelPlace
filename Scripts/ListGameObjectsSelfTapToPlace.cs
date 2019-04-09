using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity;

public class ListGameObjectsSelfTapToPlace : MonoBehaviour,IInputClickHandler {

    GameObject[] Chairs;
    List<GameObject> Lable_List = new List<GameObject>();

    GameObject hitObject;
    bool HittingButton=false;

    bool IsPlacing = false;
    int tapCountForLabel=0;
    int maxTapCount;
   
    // Use this for initialization
    void Start()
    {

        Chairs = GameObject.FindGameObjectsWithTag("Chair");
        maxTapCount = Chairs.Length;

        for (int index = 0; index < Chairs.Length; index++)
        {
            Lable_List.Add(Chairs[index]);
        }

        for (int index = 0; index < Lable_List.Count; index++)
        {
            Debug.Log("Object in Lable_List[" + index + "] is :" + Lable_List[index].name);
        }

        InputManager.Instance.PushModalInputHandler(this.gameObject);

    }
    
   


    void Update()
    {
        RaycastHit hitInfo;

        HittingButton = false;

        //检测是否正注视ToggleButton，若是，则置HittingButton为True.
        if (Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hitInfo))
        {
            //ToggleButton凝视的名字是Button组件
            hitObject = hitInfo.collider.gameObject;

            if (hitObject.name.Contains("Button"))
            {
                HittingButton = true;
                //Debug.Log("The user is gazing at "+hitObject.name);
            }
           
        }


        if (tapCountForLabel == 1 && IsPlacing)
        {
            Lable_List[0].SendMessage("Instantiate");
        }

        if (tapCountForLabel == 2 && IsPlacing)
        {
            Lable_List[1].SendMessage("Instantiate");
        }

        if (tapCountForLabel == 3 && IsPlacing)
        {
            Lable_List[2].SendMessage("Instantiate");
        }

        if (tapCountForLabel == 4 && IsPlacing)
        {
            Lable_List[3].SendMessage("Instantiate");
        }

        if (tapCountForLabel == 5 && IsPlacing)
        {
            Lable_List[4].SendMessage("Instantiate");
        }

        if (tapCountForLabel == 6 && IsPlacing)
        {
            Lable_List[5].SendMessage("Instantiate");
        }      

    }


    public void OnInputClicked(InputClickedEventData eventData)
    {
        //Debug.Log("The Value of HittingButton: " + HittingButton);

        if (HittingButton == false)
        {
            tapCountForLabel++;
            IsPlacing = true;
        }
    }


}







/*

    Lable_List[1].transform.position = GazeManager.Instance.HitPosition;
    Debug.Log("Position: " + GazeManager.Instance.HitPosition);
    Debug.Log("Normal: " + GazeManager.Instance.HitNormal);

    Lable_List[2].transform.position = GazeManager.Instance.HitPosition;
    Debug.Log("Position: " + GazeManager.Instance.HitPosition);
    Debug.Log("Normal: " + GazeManager.Instance.HitNormal);

    Lable_List[3].transform.position = GazeManager.Instance.HitPosition;
    Debug.Log("Position: " + GazeManager.Instance.HitPosition);
    Debug.Log("Normal: " + GazeManager.Instance.HitNormal);

    Lable_List[4].transform.position = GazeManager.Instance.HitPosition;
    Debug.Log("Position: " + GazeManager.Instance.HitPosition);
    Debug.Log("Normal: " + GazeManager.Instance.HitNormal);

    Lable_List[5].transform.position = GazeManager.Instance.HitPosition;
    Debug.Log("Position: " + GazeManager.Instance.HitPosition);
    Debug.Log("Normal: " + GazeManager.Instance.HitNormal);
*/







