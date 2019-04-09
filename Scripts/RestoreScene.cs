using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;
using UnityEngine.XR.WSA.Persistence;

public class RestoreScene : MonoBehaviour {

    private WorldAnchorStore anchorStore;
    private Dictionary<string, GameObject> SceneObjects = new Dictionary<string, GameObject>();


	// Use this for initialization
	void Start () {
        WorldAnchorStore.GetAsync(WorldAnchorStoreLoaded);
		
	}

    private void WorldAnchorStoreLoaded(WorldAnchorStore store)
    {
        this.anchorStore = store;
    }

    public bool SaveSceneObject(string objectID,WorldAnchor anchor)
    {
        var result= this.anchorStore.Save(objectID, anchor);
        if(result)
        {
            SceneObjects.Add(objectID,anchor.gameObject);
        }
        return result;

    }

    public WorldAnchor LoadSceneObject(string objectID)
    {
        if(SceneObjects.ContainsKey(objectID))
        {
            var target = SceneObjects[objectID];
            return this.anchorStore.Load(objectID, target);
        }
        return null;
    }

    public void RestoreAllSceneObjects()
    {
        foreach(var key in SceneObjects.Keys)
        {
            var target = SceneObjects[key];
            this.anchorStore.Load(key, target);


        }
    }



}
