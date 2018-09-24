using UnityEngine;

public class PlayerCameraFollow : MonoBehaviour
{

	#region Variables
	public Transform target;
	public float smoothSpeed = 10f;
	public Vector3 offset;
	public float zoomSpeed = 300f;

	#endregion

	#region Methods

	void FixedUpdate()
	{
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
		transform.position = smoothedPosition;

		transform.LookAt(target);
	}

	void Update()
	{
		var mouseScroll = Input.GetAxis("Mouse ScrollWheel");

		if (mouseScroll != 0)
		{
			transform.Translate(transform.forward * mouseScroll * zoomSpeed * Time.deltaTime, Space.Self);
		}
	}

	#endregion
}
