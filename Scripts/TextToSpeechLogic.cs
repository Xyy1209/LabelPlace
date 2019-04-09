using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule; 

public class TextToSpeechLogic : MonoBehaviour,IFocusable
{

    private TextToSpeech textToSpeech;
    public string speakText;


    void Awake()
    {
        textToSpeech = this.gameObject.GetComponent<TextToSpeech>();
    }

    public void OnFocusEnter()
    {
        Debug.Log("TextToSpeech is launching...");
        //string.Format(String,Object):将指定的String中的格式替换为指定的Object 实例 的值的文本等效项
        var msg = string.Format(speakText, textToSpeech.Voice.ToString());
        textToSpeech.StartSpeaking(msg);
    }

    public void OnFocusExit()
    {
        Debug.Log("TextToSpeech is finished...");
       
    }
}
