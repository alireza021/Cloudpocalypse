var minFov: float = 5f;
 var maxFov: float = 200f;
 var sensitivity: float = 50f;
 
 function LateUpdate () {
   var fov: float = Camera.main.fieldOfView;
   fov -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
   fov = Mathf.Clamp(fov, minFov, maxFov);
   Camera.main.fieldOfView = fov;
 }