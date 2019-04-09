using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAndShowLabels : MonoBehaviour
{


    GameObject[] LabelsOfChair;
    public GameObject[] CopyLabelsOfChair;

    //转化为static
    public static  bool speakOnToggle = true;

  

    //保存隐藏标签前，标签的Transform
    Vector3[] labelsPosition = new Vector3[20];
    Quaternion[] labelsRotation = new Quaternion[20];


    // Use this for initialization
    void Update()
    {
        LabelsOfChair = GameObject.FindGameObjectsWithTag("Labels");

        //加！，当点击ShowButton重新active物体时，附加在物体上的语音不会被触发。但之后仍需在Gaze注入时输出语音，故加反 ！ 
        if (!speakOnToggle)
            speakOnToggle = !speakOnToggle;
    }



    public void Hide()
    {

        Debug.Log("Hide Method Is Starting...");

        if (LabelsOfChair.Length < 1)
            Debug.Log("Hide Labels: LabelsOfChair is null.");
        else
        {
            CopyLabelsOfChair = new GameObject[LabelsOfChair.Length];

            for (int i = 0; i < LabelsOfChair.Length; i++)
            {
                CopyLabelsOfChair[i] = LabelsOfChair[i];
                labelsPosition[i] = LabelsOfChair[i].transform.position;
                labelsRotation[i] = LabelsOfChair[i].transform.rotation;
            }
        }


        foreach (GameObject obj in LabelsOfChair)
        {
            Debug.Log(obj.name);
            
            obj.SetActive(false);
        }

    }



    public void Show()
    {
        Debug.Log("The value of SpeakOnToggle: " + speakOnToggle);

        for (int i = 0; i < CopyLabelsOfChair.Length; i++)
        {
            CopyLabelsOfChair[i].SetActive(true);
            CopyLabelsOfChair[i].transform.position = labelsPosition[i];
            CopyLabelsOfChair[i].transform.rotation = labelsRotation[i];
            speakOnToggle = false;
        }

    }



}
