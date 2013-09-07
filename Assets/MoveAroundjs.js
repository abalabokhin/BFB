#pragma strict

//var planets;
//
//function start () {
//	if (planets == null) {
//		planets	= gameobject.findgameobjectswithtag ("planet");
//	}
//}
//
//var speed = 10.0;
//var rotatespeed = 10.0;
//
//function update () {
//	var controller : charactercontroller = getcomponent(charactercontroller);
//	
//	transform.rotate(0, input.getaxis("horizontal") * rotatespeed, 0);
//	
//	var forward = transform.transformdirection(vector3.forward);
//	var curspeed = speed * input.getaxis("vertical");
//	controller.simplemove(forward * curspeed);
//
//	var position = transform.position; 
//	for (var planet : gameobject in planets) {
//		var diff = (planet.transform.position - position);
//		var curdistance = diff.sqrmagnitude; 
//		debug.log(curdistance);
//	}
//
//}
//@script requirecomponent(charactercontroller)