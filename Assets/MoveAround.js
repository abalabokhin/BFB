#pragma strict

var planets;

function Start () {
	if (planets == null) {
		planets	= GameObject.FindGameObjectsWithTag ("Planet");
	}
}

var speed = 10.0;
var rotateSpeed = 10.0;

function Update () {
	var controller : CharacterController = GetComponent(CharacterController);
	
	transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
	
	var forward = transform.TransformDirection(Vector3.forward);
	var curSpeed = speed * Input.GetAxis("Vertical");
	controller.SimpleMove(forward * curSpeed);

	var position = transform.position; 
	for (var planet : GameObject in planets) {
		var diff = (planet.transform.position - position);
		var curDistance = diff.sqrMagnitude; 
		Debug.Log(curDistance);
	}

}
@script RequireComponent(CharacterController)