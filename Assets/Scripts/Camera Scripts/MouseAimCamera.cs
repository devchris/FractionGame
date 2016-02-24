using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MouseAimCamera : MonoBehaviour {
	public GameObject target;
	public float rotateSpeed = 5;
	Vector3 offset;
	
	void Start() {
		offset = target.transform.position - transform.position;
        //Cursor.visible = false;
        //Screen.showCursor = false;
    }
	
	void LateUpdate() {
		float horizontal = -Input.GetAxis("Mouse X") * rotateSpeed;
		target.transform.Rotate(0, -horizontal, 0);

		float desiredAngle = target.transform.eulerAngles.y;
		Quaternion rotation = Quaternion.Euler(5, desiredAngle+90, 5);
		transform.position = target.transform.position - (rotation * offset);
		
		transform.LookAt(target.transform);
	}
}