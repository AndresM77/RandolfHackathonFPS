using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
	[SerializeField]
	private Camera cam;


	private Vector3 MotorVelocity = Vector3.zero;
	private Vector3 MotorRotation = Vector3.zero;
	private Vector3 MotorCameraRotation = Vector3.zero;


	private Rigidbody rb;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody>();

	}

	public void Move(Vector3 velocity)
	{
		MotorVelocity = velocity;
	}

	public void Rotate(Vector3 rotation)
	{
		MotorRotation = rotation;

	}

	public void RotateCamera(Vector3 camerarotation)
	{
		MotorCameraRotation = camerarotation;

	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		PerformMovement();
		PerformRotation();
	}

	void PerformMovement()
	{
		if (MotorVelocity != Vector3.zero)
		{
			rb.MovePosition(rb.position + MotorVelocity * Time.fixedDeltaTime);
		}
	}

	void PerformRotation()
	{
		rb.MoveRotation(rb.rotation * Quaternion.Euler(MotorRotation));
		if (cam != null)
		{
			cam.transform.Rotate(-MotorCameraRotation);
		}
	}


}
