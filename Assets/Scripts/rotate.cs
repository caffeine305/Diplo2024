using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {


	public float rotationVelocity;
    public Vector3 rot = Vector3.zero;
	
	void Update () {
        this.transform.Rotate(rot*Time.deltaTime * rotationVelocity);
	}
}
