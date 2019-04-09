using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.XR.WSA;
using HoloToolkit.Unity;
using System;
using UnityEngine.XR.WSA.Persistence;

public class AnchorLeg : MonoBehaviour, IManipulationHandler, IFocusable
{

    public string AnchorName;
    public bool Undo = false;

    public string speakText;
    public int speakCount;

    private Vector3 oldPosition;
    private Quaternion oldRotation;
    private Vector3 savedPosition;
    private Quaternion savedRotation;

    private TextToSpeech textToSpeech;



    void Awake()
    {
        textToSpeech = this.gameObject.GetComponentInChildren<TextToSpeech>();
    }


    // Use this for initialization
    void Start()
    {

        oldPosition = savedPosition = this.gameObject.transform.position;
        oldRotation = savedRotation = this.gameObject.transform.rotation;

        WorldAnchorManager.Instance.AttachAnchor(this.gameObject, AnchorName);
        Debug.Log("Start方法-------Anchor Attached for: " + this.gameObject.name + "-------- Anchor ID -------" + AnchorName);

    }



    // Update is called once per frame
    void Update()
    {
        //Undo标志表示取消锚
        if (Undo)
        {
            WorldAnchorManager.Instance.RemoveAnchor(this.gameObject);
            RestoreBackUpAnchor();
            Undo = false;
        }

    }


    //恢复后备锚
    private void RestoreBackUpAnchor()
    {
        this.gameObject.transform.position = oldPosition;
        this.gameObject.transform.rotation = oldRotation;
        WorldAnchorManager.Instance.AttachAnchor(this.gameObject, AnchorName);
        Debug.Log("RestoreBakUpAnchor方法-------Anchor Attached for: " + this.gameObject.name + "-------Anchor ID------" + AnchorName);
    }


    public void OnFocusEnter()
    {
        this.gameObject.GetComponentInChildren<TextMesh>().fontSize = 65;

        if (textToSpeech == null)
        {
            Debug.LogError("TextToSpeech is null.");
        }

        else if(HideAndShowLabels.speakOnToggle)
        {
            var msg = string.Format(speakText, textToSpeech.Voice.ToString());
            textToSpeech.StartSpeaking(msg);
            speakCount++;
            Debug.Log("TextToSpeech is starting...");
        }

    }


    public void OnFocusExit()
    {
        savedPosition = this.gameObject.transform.position;
        savedRotation = this.gameObject.transform.rotation;

        this.gameObject.GetComponentInChildren<TextMesh>().fontSize = 55;

        Debug.Log("TextToSpeech is finished.");
    }

    public void AttachAnchor()
    {
        oldPosition = savedPosition = this.gameObject.transform.position;
        oldRotation = savedRotation = this.gameObject.transform.rotation;

        WorldAnchorManager.Instance.AttachAnchor(this.gameObject, AnchorName);
        Debug.Log("AttachAnchor方法-------Anchor Attached for: " + this.gameObject.name + "------ Anchor Id ------" + AnchorName);
    }

    public void UpdateAndRemoveAnchor()
    {
        oldPosition = savedPosition = this.gameObject.transform.position;
        oldRotation = savedRotation = this.gameObject.transform.rotation;
        WorldAnchorManager.Instance.RemoveAnchor(this.gameObject);
        Debug.Log("UpdateAndRemoveAnchor方法-------Anchor Removed for: " + this.gameObject.name + "------ Anchor ID ------" + AnchorName);
    }

    public void OnManipulationStarted(ManipulationEventData eventData)
    {
        WorldAnchorManager.Instance.RemoveAnchor(this.gameObject);
        Debug.Log("OnManipulationStarted方法 ------ Anchor Removed ------");
        oldPosition = savedPosition;
        oldRotation = savedRotation;

    }

    public void OnManipulationUpdated(ManipulationEventData eventData)
    {

    }

    public void OnManipulationCompleted(ManipulationEventData eventData)
    {
        WorldAnchorManager.Instance.AttachAnchor(this.gameObject, AnchorName);
        Debug.Log("OnManipulationCompleted方法 ------ Anchor Attached ------");

    }

    public void OnManipulationCanceled(ManipulationEventData eventData)
    {

    }
}
