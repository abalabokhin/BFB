#pragma strict

function Start () {

}

var speed = 10.0;
var rotateSpeed = 10.0;

function Update () {
	var controller : CharacterController = GetComponent(CharacterController);
	
	transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
	
	var forward = transform.TransformDirection(Vector3.forward);
	var curSpeed = speed * Input.GetAxis("Vertical");
	controller.SimpleMove(forward * curSpeed);

}
@script RequireComponent(CharacterController)