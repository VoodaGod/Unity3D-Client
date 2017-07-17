﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NRPBackendManager : MonoBehaviour {

    public string NRPBackendIP = "192.168.0.153";
    public int GzBridgePort = 8080;
    public int ROSBridgePort = 9090;
    public GameObject GazeboScene = null;

    private GzBridgeManager GzBridgeManager;
    private ROSBridge ROSBridgeManager;

	// Use this for initialization
	void Start ()
    {
        // initialize GzBridge component
        if (this.gameObject.GetComponent<GzBridgeManager>() == null)
        {
            this.gameObject.AddComponent<GzBridgeManager>();
        }
        this.GzBridgeManager = this.gameObject.GetComponent<GzBridgeManager>();

        // initialize ROSBridge component
        if (this.gameObject.GetComponent<ROSBridge>() == null)
        {
            this.gameObject.AddComponent<ROSBridge>();
        }
        this.ROSBridgeManager = this.gameObject.GetComponent<ROSBridge>();

        if (!string.IsNullOrEmpty(this.NRPBackendIP))
        {
            GzBridgeManager.URL = NRPBackendIP + ":" + GzBridgePort.ToString() + "/gzbridge";
            GzBridgeManager.GazeboScene = this.GazeboScene;
            GzBridgeManager.ConnectToGzBridge();

            ROSBridgeManager.ROSCoreIP = NRPBackendIP;
            ROSBridgeManager.Port = ROSBridgePort;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}