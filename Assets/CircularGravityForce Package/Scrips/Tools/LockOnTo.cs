/*******************************************************************************************
* Author: Lane Gresham, AKA LaneMax
* Websites: http://resurgamstudios.com
* Version: 3.10
* Created Date: 08-23-15
* Last Updated: 08-23-15
* Description: Used for making the current Transform lock on to target transform.
*******************************************************************************************/
using UnityEngine;
using System.Collections;

namespace CircularGravityForce
{
    public class LockOnTo : MonoBehaviour
    {
        #region Properties

        [SerializeField]
        private CircularGravity.ConstraintProperties.AlignDirection alignDirection;
        public CircularGravity.ConstraintProperties.AlignDirection _alignDirection
        {
            get { return alignDirection; }
            set { alignDirection = value; }
        }

        [SerializeField]
        private Transform target;
        public Transform Target
        {
            get { return target; }
            set { target = value; }
        }

        [SerializeField]
        private bool rotationRigidbody = false;
        public bool RotationRigidbody
        {
            get { return rotationRigidbody; }
            set { rotationRigidbody = value; }
        }

        [SerializeField]
        private float slerpSpeed = 8f;
        public float SlerpSpeed
        {
            get { return slerpSpeed; }
            set { slerpSpeed = value; }
        }

        private Transform myTransform;
        private Rigidbody myRigidbody;

        #endregion

        #region Unity Functions

        // Use this for initialization
        void Start()
        {
            if (RotationRigidbody)
            {
                myRigidbody = this.GetComponent<Rigidbody>();
                myTransform = myRigidbody.transform;
            }
            else
            {
                myTransform = this.transform;
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (Target != null)
            {
                Vector3 up = (myTransform.position - Target.position).normalized;
                Vector3 newLocal = Vector3.zero;

                switch (_alignDirection)
                {
                    case CircularGravity.ConstraintProperties.AlignDirection.Up:
                        newLocal = myTransform.up;
                        break;
                    case CircularGravity.ConstraintProperties.AlignDirection.Down:
                        newLocal = -myTransform.up;
                        break;
                    case CircularGravity.ConstraintProperties.AlignDirection.Left:
                        newLocal = -myTransform.right;
                        break;
                    case CircularGravity.ConstraintProperties.AlignDirection.Right:
                        newLocal = myTransform.right;
                        break;
                    case CircularGravity.ConstraintProperties.AlignDirection.Forward:
                        newLocal = myTransform.forward;
                        break;
                    case CircularGravity.ConstraintProperties.AlignDirection.Backword:
                        newLocal = -myTransform.forward;
                        break;
                }

                var targetRotation = Quaternion.FromToRotation(newLocal, up) * myTransform.rotation;
                var newRotation = Quaternion.Slerp(myTransform.rotation, targetRotation, Time.deltaTime * SlerpSpeed);

                if (RotationRigidbody)
                    myRigidbody.MoveRotation(newRotation);
                else
                    myTransform.rotation = (newRotation);

            }
        }

        #endregion
    }
}
