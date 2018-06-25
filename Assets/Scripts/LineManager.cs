using System.IO;
using UnityEngine;
using UnityExtension;

public class LineManager : MonoBehaviour {

	private MeshLineRenderer curLine;
	public GameObject place;
    GameObject collection;
    private MeshFilter m_MeshFilter;
    // Use this for initialization
    void Start () {
        collection = new GameObject();
        //collection.AddComponent<Example>();
        //collection.AddComponent<MeshFilter>();
        //collection.AddComponent<MeshToOBJ>();
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetButtonDown("Fire1"))
        {

            GameObject line = new GameObject();
            line.transform.parent = collection.transform;
            m_MeshFilter = line.AddComponent<MeshFilter>();
            line.AddComponent<MeshRenderer>();
            curLine = line.AddComponent<MeshLineRenderer>();
            
            curLine.setWidth(0.05f);

        }
        if (Input.GetButton("Fire1"))
        {
            curLine.AddPoint(place.transform.position);

        }

        if (Input.GetButtonUp("Fire1"))
        {
            
            var lStream = new FileStream("C:/Users/apappu/Documents/NoBillBoardLines/Assets/line.obj", FileMode.Create);
            var lOBJData = m_MeshFilter.sharedMesh.EncodeOBJ();
            OBJLoader.ExportOBJ(lOBJData, lStream);
            lStream.Close();
            
        }
	}
}
