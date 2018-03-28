using System.Collections.Generic;
using UnityEngine;

public class LineRendererScript : MonoBehaviour {

	// Use this for initialization
	public GameObject place;
	private GameObject lineObject;
	private List<Vector3> positions; 
	private  Vector3 currentPosition;
	private Vector3 lastPosition;
	private LineRenderer line;
	public float magnitudeVarience;
	public float angleVarience;

	void Start () {
		positions = new List<Vector3>();
	}

	// Update is called once per frame
	void Update()
	{
        /*
		if (Input.GetButtonDown("Fire1"))
		{
			lineObject = new GameObject();
			line = lineObject.AddComponent<LineRenderer>();
			line.useWorldSpace = true;
			line.startWidth = 0.1f;
			line.receiveShadows = false;
			line.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;


			positions.Add(place.transform.position);
			currentPosition = positions[positions.Count-1];
			lastPosition = positions[positions.Count - 1];


			//lastPosition = place.transform.position;
			//positions.Add(place.transform.position);
		}
		if (Input.GetButton("Fire1"))
		{
			///
			currentPosition = place.transform.position;

			if (positions[positions.Count - 1] != currentPosition)
			{
				if (Vector3.Angle(currentPosition, positions[positions.Count - 1]) > angleVarience)
				if ((currentPosition - positions[positions.Count - 1]).magnitude > magnitudeVarience )
				{
					positions.Add(place.transform.position);
					line.positionCount = positions.Count;
					line.SetPositions(positions.ToArray());
				}
			}

			lastPosition = currentPosition;
		}
		if (Input.GetButtonUp("Fire1"))
		{
			WriteToFile();
			positions.Clear();
		}
        */
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

