using System.IO;
using UnityEngine;
using UnityExtension;

public class MeshToOBJ : MonoBehaviour {

    // Use this for initialization
    public bool print = false;
    private MeshFilter m_MeshFilter;
    void Start () {
        m_MeshFilter = GetComponent<MeshFilter>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if (print)
        {
            var lStream = new FileStream("C:/Users/apappu/Documents/NoBillBoardLines/Assets/line.obj", FileMode.Create);
            var lOBJData = m_MeshFilter.sharedMesh.EncodeOBJ();
            OBJLoader.ExportOBJ(lOBJData, lStream);
            lStream.Dispose();
            print = false;
        }
	}
}
