using UnityEngine;
using System.Collections;
// oroginal code is : https://answers.unity.com/questions/461588/drawing-a-bounding-box-similar-to-box-collider.html 

[ExecuteInEditMode()] 

public class ShowMeshBounds : MonoBehaviour {
	public Color color = Color.green;

	private Vector3 v3FrontTopLeft;
	private Vector3 v3FrontTopRight;
	private Vector3 v3FrontBottomLeft;
	private Vector3 v3FrontBottomRight;
	private Vector3 v3BackTopLeft;
	private Vector3 v3BackTopRight;
	private Vector3 v3BackBottomLeft;
	private Vector3 v3BackBottomRight;    

	void Update() {
		CalcPositons();
		DrawBox();
	}

	void CalcPositons(){

		Bounds bounds;
		if (GetComponent<MeshRenderer> ())
			bounds = GetComponent<MeshRenderer> ().bounds;
		else if (GetComponent<SkinnedMeshRenderer> ()) {
			bounds = GetComponent<SkinnedMeshRenderer> ().bounds;	
		}
		else
			return;

		Vector3 v3Center = bounds.center;
		Vector3 v3Extents = bounds.extents;

		v3FrontTopLeft     = new Vector3(v3Center.x - v3Extents.x, v3Center.y + v3Extents.y, v3Center.z - v3Extents.z);  // Front top left corner
		v3FrontTopRight    = new Vector3(v3Center.x + v3Extents.x, v3Center.y + v3Extents.y, v3Center.z - v3Extents.z);  // Front top right corner
		v3FrontBottomLeft  = new Vector3(v3Center.x - v3Extents.x, v3Center.y - v3Extents.y, v3Center.z - v3Extents.z);  // Front bottom left corner
		v3FrontBottomRight = new Vector3(v3Center.x + v3Extents.x, v3Center.y - v3Extents.y, v3Center.z - v3Extents.z);  // Front bottom right corner
		v3BackTopLeft      = new Vector3(v3Center.x - v3Extents.x, v3Center.y + v3Extents.y, v3Center.z + v3Extents.z);  // Back top left corner
		v3BackTopRight     = new Vector3(v3Center.x + v3Extents.x, v3Center.y + v3Extents.y, v3Center.z + v3Extents.z);  // Back top right corner
		v3BackBottomLeft   = new Vector3(v3Center.x - v3Extents.x, v3Center.y - v3Extents.y, v3Center.z + v3Extents.z);  // Back bottom left corner
		v3BackBottomRight  = new Vector3(v3Center.x + v3Extents.x, v3Center.y - v3Extents.y, v3Center.z + v3Extents.z);  // Back bottom right corner
	}

	void DrawBox() {
		Debug.DrawLine (v3FrontTopLeft, v3FrontTopRight, color);
		Debug.DrawLine (v3FrontTopRight, v3FrontBottomRight, color);
		Debug.DrawLine (v3FrontBottomRight, v3FrontBottomLeft, color);
		Debug.DrawLine (v3FrontBottomLeft, v3FrontTopLeft, color);

		Debug.DrawLine (v3BackTopLeft, v3BackTopRight, color);
		Debug.DrawLine (v3BackTopRight, v3BackBottomRight, color);
		Debug.DrawLine (v3BackBottomRight, v3BackBottomLeft, color);
		Debug.DrawLine (v3BackBottomLeft, v3BackTopLeft, color);

		Debug.DrawLine (v3FrontTopLeft, v3BackTopLeft, color);
		Debug.DrawLine (v3FrontTopRight, v3BackTopRight, color);
		Debug.DrawLine (v3FrontBottomRight, v3BackBottomRight, color);
		Debug.DrawLine (v3FrontBottomLeft, v3BackBottomLeft, color);
	}

}