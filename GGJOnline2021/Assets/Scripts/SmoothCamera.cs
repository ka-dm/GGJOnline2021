using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SmoothCamera : MonoBehaviour
{

	public Transform target;

	public float smoothSpeed = 0.125f;
	public Vector3 offset;

   
    void LateUpdate()
	{
        CameraControl();


    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            MeshRenderer renderer = other.gameObject.GetComponent<MeshRenderer>();
            renderer.material.color = colorFade;
        }
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            MeshRenderer renderer = other.gameObject.GetComponent<MeshRenderer>();
            renderer.material.color = Color.white;
        }
    }
    */

    public void CameraControl()
    {
        //Vector3 desiredPosition = target.position + offset;
		//Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, target.position, smoothSpeed);
        transform.position = smoothedPosition;
    }

}