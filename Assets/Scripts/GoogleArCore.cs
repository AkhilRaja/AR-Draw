using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;
using GoogleARCore.CrossPlatform;
using GoogleARCore.Examples.Common;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GoogleArCore : MonoBehaviour {


    [Header("ARCore")]

    /// <summary>
    /// The root for ARCore-specific GameObjects in the scene.
    /// </summary>
    public GameObject ARCoreRoot;


    /// <summary>
    /// The last placed anchor.
    /// </summary>
    private Component m_LastPlacedAnchor = null;

    /// <summary>
    /// The last resolved anchor.
    /// </summary>
    private XPAnchor m_LastResolvedAnchor = null;



    private ApplicationMode m_CurrentMode = ApplicationMode.Ready;

    public enum ApplicationMode
    {
        Ready,
        Hosting,
        Resolving,
    }

    // Use this for initialization
    void Start () {

        if (Application.platform != RuntimePlatform.IPhonePlayer)
        {
            ARCoreRoot.SetActive(true);
        }

        _ResetStatus();
    }

    // Update is called once per frame

    void Update () {
	
        
	}




    private void _ResetStatus()
    {
        // Reset internal status.
        m_CurrentMode = ApplicationMode.Ready;
        if (m_LastPlacedAnchor != null)
        {
            Destroy(m_LastPlacedAnchor.gameObject);
        }

        m_LastPlacedAnchor = null;
        if (m_LastResolvedAnchor != null)
        {
            Destroy(m_LastResolvedAnchor.gameObject);
        }

        m_LastResolvedAnchor = null;
      
    }

}
