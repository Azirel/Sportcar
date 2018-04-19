/*
 * @author Valentin Simonov / http://va.lent.in/
 */

using UnityEngine;
using TouchScript.Gestures.TransformGestures;

namespace TouchScript.Examples.CameraControl
{
    /// <exclude />
    public class MyCameraController : MonoBehaviour
    {
        public ScreenTransformGesture ManipulationGesture;
        public float PanSpeed = 200f;
        public float RotationSpeed = 200f;
        public float ZoomSpeed = 10f;
        public Transform pivot;
        public Transform cam;
        public float smoothTime = 0.08f;

        private Vector3 eulerTarget;
        private Vector3 velocity;

        private void OnEnable()
        {
            ManipulationGesture.Transformed += Rotator;
            cam.transform.LookAt(pivot);
        }

        private void OnDisable()
        {
            ManipulationGesture.Transformed -= Rotator;
        }

        private void manipulationTransformedHandler(object sender, System.EventArgs e)
        {
            var rotation = Quaternion.Euler(ManipulationGesture.DeltaPosition.y / Screen.height * RotationSpeed,
                -ManipulationGesture.DeltaPosition.x / Screen.width * RotationSpeed,
                /*ManipulationGesture.DeltaRotation*/0);

            pivot.localRotation *= rotation;
            cam.transform.localPosition += Vector3.forward * (ManipulationGesture.DeltaScale - 1f) * ZoomSpeed;
        }

        private void Rotator(object sender, System.EventArgs e)
        {
            eulerTarget = pivot.transform.localEulerAngles + new Vector3(ManipulationGesture.DeltaPosition.y, ManipulationGesture.DeltaPosition.x, 0) * RotationSpeed;
        }

        private void Update()
        {
            pivot.transform.localEulerAngles = Vector3.Slerp(pivot.transform.localEulerAngles, eulerTarget, /*ref velocity,*/ smoothTime);
            pivot.transform.localEulerAngles = new Vector3(pivot.transform.localEulerAngles.x, pivot.transform.localEulerAngles.y, 0);
        }

        //private void twoFingerTransformHandler(object sender, System.EventArgs e)
        //{
        //    pivot.localPosition += pivot.rotation * TwoFingerMoveGesture.DeltaPosition * PanSpeed;
        //}
    }
}