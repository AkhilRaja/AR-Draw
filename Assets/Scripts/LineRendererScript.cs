using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LineRendererScript : NetworkBehaviour {

	// Use this for initialization
	public GameObject place;
	public GameObject lineObject;

	private List<Vector3> positions; 
	private  Vector3 currentPosition;
	private Vector3 lastPosition;
	private LineRenderer line;
	public float magnitudeVarience;
	public float angleVarience;
    public float width;
    public Material _material;
    public bool createNewObject = false;
    public CubeController cube;
    public float frameDistance;

    void Start () {

        cube = this.gameObject.GetComponent<CubeController>();
		positions = new List<Vector3>();
        positions.Clear();
    }

	// Update is called once per frame
	void Update()
	{
        if (cube.isButtonDown || (positions.Count == 0))
        {
            if (line == null || line.positionCount > 2)
            {

                var lineGameObject = Instantiate(lineObject, transform.position, Quaternion.identity);
                line = lineGameObject.GetComponent<LineRenderer>();
                lineGameObject.transform.parent = this.transform;
            }
            positions.Clear();
            positions.Add(this.transform.position);
            //lastPosition = transform.position;

        }   

        if (cube.isButton)
            {

                currentPosition = this.transform.position;

                if (lastPosition != currentPosition)
                {
                   
                            positions.Add(this.transform.position);
                            line.positionCount = positions.Count;
                            line.SetPositions(positions.ToArray());
                    
                }
                frameDistance = Vector3.Distance(currentPosition, lastPosition);
                lastPosition = currentPosition;
            }


        if (cube.isButtonUp || frameDistance > 0.1)
        {
            positions.Clear();
        }
      //  Debug.Log(frameDistance);


    }



    private void WriteToFile()
	{
        /*
		string path = "Assets/Resources/test.txt";
		StreamWriter streamWriter = new StreamWriter(path, true);

		string jsonString = JsonHelper.ToJson(positions.ToArray(),true);
		streamWriter.WriteLine(jsonString);
		streamWriter.Close();

    */
	}
}

