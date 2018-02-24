using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerControler : MonoBehaviour
{

	[SerializeField]
	private float speed = 10f;
	[SerializeField]
	private float RotationSpeed = 3f;

	private PlayerMotor motor;

	void Start()
	{
		motor = GetComponent<PlayerMotor>();

	}

	void Update()
	{

		float xMove = Input.GetAxisRaw("Horizontal");
		float zMove = Input.GetAxisRaw("Vertical");

		Vector3 MoveHorizontal = transform.right * xMove;
		Vector3 MoveVertical = transform.forward * zMove;

		Vector3 ControlVelocity = (MoveHorizontal + MoveVertical).normalized * speed;

		motor.Move(ControlVelocity);


		float YRotation = Input.GetAxisRaw("Mouse X");

		Vector3 ControlRotation = new Vector3(0f, YRotation, 0f) * RotationSpeed;
		motor.Rotate(ControlRotation);

		float XRotation = Input.GetAxisRaw("Mouse Y");

		Vector3 CameraRotation = new Vector3(XRotation, 0f, 0f) * RotationSpeed;
		motor.RotateCamera(CameraRotation);


	}
}



