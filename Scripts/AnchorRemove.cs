using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

public class AnchorRemove : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if(this.gameObject.GetComponent<WorldAnchor>()!=null)
        {
            DestroyImmediate(gameObject.GetComponent<WorldAnchor>());
            gameObject.transform.position = GazeManager.Instance.HitPosition;
        }
		
	}
	

}
