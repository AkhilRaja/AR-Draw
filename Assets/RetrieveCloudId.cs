using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RetrieveCloudId : NetworkBehaviour{

    // Use this for initialization
    public string cloudID;

    public GameObject[] gameObjects;

    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        gameObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject game in gameObjects)
        {
            if (game.GetComponent<CubeController>().anchorID != "")
            {
                cloudID = game.GetComponent<CubeController>().anchorID;
            }
        }
	}
}
