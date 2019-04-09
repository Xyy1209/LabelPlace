using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

//暂时取消旋转继承的INavigationHandler
public class ManipulationAndNavigation : MonoBehaviour, IManipulationHandler
{


    private Vector3 origPosition;
    float rotateSentivity = 10.0f;
    float moveSentivity = 1.5f;

    void Start()
    {
        transform.position = GazeManager.Instance.HitPosition;
    }

    public void OnManipulationStarted(ManipulationEventData eventData)
    {
        origPosition = this.gameObject.transform.position;
    }

    public void OnManipulationUpdated(ManipulationEventData eventData)
    {
        Vector3 move = new Vector3(eventData.CumulativeDelta.x, eventData.CumulativeDelta.y, eventData.CumulativeDelta.z);
        Vector3 newPositon = origPosition + move * moveSentivity;
        transform.position = newPositon;
    }

    public void OnManipulationCompleted(ManipulationEventData eventData)
    {

    }


    public void OnManipulationCanceled(ManipulationEventData eventData)
    {

    }


    public void OnNavigationStarted(NavigationEventData eventData)
    {

    }

    /*先将旋转取消
    public void OnNavigationUpdated(NavigationEventData eventData)
    {
        //绕y轴旋转
        float rotationFactor = eventData.CumulativeDelta.x * rotateSentivity;
        transform.Rotate(new Vector3(0, -1 * rotationFactor, 0));
    }


    public void OnNavigationCompleted(NavigationEventData eventData)
    {

    }


    public void OnNavigationCanceled(NavigationEventData eventData)
    {

    }
    */


}
