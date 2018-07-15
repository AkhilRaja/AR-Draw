using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using GoogleARCore;
using GoogleARCore.CrossPlatform;
using UnityEngine.UI;


public class CubeController : NetworkBehaviour {

    public bool isButtonDown;
    public bool isButton;
    public bool isButtonUp;

    public bool check1 = false;
    public bool check2 = false;
    public bool check3 = false;

    public Component mComponent = null;
    public XPAnchor mCloudAnchor;
    public GameObject text;
    private Text message;

    public string anchorID = "";

    public GameObject CloudGuy;


    private float time = 10;
    public XPAnchor clientAnchor;

    void Start () {

        CloudGuy = GameObject.Find("CloudGuy");
        text =  GameObject.Find("DebugText");
        message = text.GetComponent<Text>();

        message.text = "In Start";
	}

    [Command]
    public void CmdSetInputButton(bool value)
    {
        RpcSetInputButton(value);
    }


    [ClientRpc]
    public void RpcSetInputButton(bool value)
    {
        isButton = value;
    }


    [Command]
    public void CmdSetInputButtonDown(bool value)
    {
        RpcSetInputButtonDown(value);
    }


    [ClientRpc]
    public void RpcSetInputButtonDown(bool value)
    {
        isButtonDown = value;
    }

    [Command]
    public void CmdSetInputButtonUp(bool value)
    {
        RpcSetInputButtonUp(value);
    }


    [ClientRpc]
    public void RpcSetInputButtonUp(bool value)
    {
        isButtonUp = value;
    }

   [ClientRpc]
    public void RpcSetCloudid(string value) {
        anchorID = value; 
    }


    void Update () {



        if (!isLocalPlayer)
        { return; }
        
        //Not Server then Excecute
        if (!isServer)
        {

            //Code to Resolve the Anchor and Display resolved Anchor
            //Step - 1
            //Check if the cloudID is Null
            if(anchorID == "")
                anchorID = CloudGuy.GetComponent<RetrieveCloudId>().cloudID;
          //  message.text = "Inside Client Update : anchorId is : " + anchorID;
         //   anchorID = CloudGuy.GetComponent<RetrieveCloudId>().cloudID;

            if (anchorID != "" && clientAnchor==null)
            {
                message.text = "Resolving The Cloud Anchor .." + anchorID;

                XPSession.ResolveCloudAnchor(anchorID).ThenAction((System.Action<CloudAnchorResult>)(result =>
                {
                    if (result.Response != CloudServiceResponse.Success)
                    {
                        message.text = "Error Resolving the Client" + result.Response;
                        return;
                    }

                    message.text = "SuccessFully Resolved";
                    clientAnchor = result.Anchor;
                    clientAnchor.transform.rotation = transform.rotation;
                    this.transform.parent = clientAnchor.transform;                  
                }));
            }

            


            if (Input.GetButtonDown("Fire1"))
            {
                CmdSetInputButtonDown(true);
                check1 = true;
            }
            else
            {
                if(check1)
                     CmdSetInputButtonDown(false);

                check1 = false;
            }

            if (Input.GetButton("Fire1"))
            {
                CmdSetInputButton(true);
                check2 = true;
            }
            else
            {
                if (check2)
                    CmdSetInputButton(false);

                check2 = false;

            }

            if (Input.GetButtonUp("Fire1"))
            {
                CmdSetInputButtonUp(true);
                check3 = true;
            }
            else
            {
                if (check3)
                    CmdSetInputButtonUp(false);

                check3 = false;
            }

        }
       
        //Server Code
        else
        {
            time -= Time.deltaTime; 
            if (mComponent == null && time <= 0)
            {
                message.text = "Creating Anchor";
                mComponent = Session.CreateAnchor(Frame.Pose);

                if (mComponent != null)
                {
                    this.transform.parent = mComponent.transform;

                    var anchor = (Anchor)mComponent;
                    XPSession.CreateCloudAnchor(anchor).ThenAction(result =>
                    {
                        if (result.Response != CloudServiceResponse.Success)
                        {
                            message.text = "Failed" + result.Response;
                            return;
                        }

                        message.text = "Hosted it Successfully" + result.Anchor.CloudId;
                        anchorID = result.Anchor.CloudId;
                        RpcSetCloudid(anchorID);
                    });
                }

            }
            else if(time > 1){
                message.text = "Walk Around and Wait for Time : " + time;
            }


            if (Input.GetButtonDown("Fire1"))
            {
                RpcSetInputButtonDown(true);
           

            }
            else
            {
                RpcSetInputButtonDown(false);   
            }
            if (Input.GetButton("Fire1"))
            {
                check2 = true;
                RpcSetInputButton(true);
            }
            else
            {
                if (check2)
                    RpcSetInputButton(false);
                check2 = false;
            }
            if (Input.GetButtonUp("Fire1"))
            {
              
                RpcSetInputButtonUp(true);
            }
            else
            { 
               RpcSetInputButtonUp(false);
            }
           

        }
       

        if (Input.touchCount > 0) {

            var inputPosition = Input.GetTouch(0).position;
            this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(inputPosition.x, inputPosition.y, 0.5f));

        }

	}
}
