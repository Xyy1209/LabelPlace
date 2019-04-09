using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA.Persistence;

public class EnumerateAnchors : MonoBehaviour {

    WorldAnchorStore anchorstore;


	// Use this for initialization
	void Start ()
    {
        WorldAnchorStore.GetAsync(AnchorStoreReady);    
	}


    private void AnchorStoreReady(WorldAnchorStore store)
    {
        this.anchorstore = store;
        string[] IDs=this.anchorstore.GetAllIds();
        if(IDs.Length==0)
        {
            print("No Anchors!");
        }
        for(int index=0;index<IDs.Length;index++)
        {
            Debug.Log(IDs[index]);
        }
    }

    
}
