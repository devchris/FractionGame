/*******************************************************************************************
* Author: Lane Gresham, AKA LaneMax
* Websites: http://resurgamstudios.com
* Version: 3.10
* Created Date: 08-23-15
* Last Updated: 08-23-15
* Description: Used turning Rocket Explosion prefab.
*******************************************************************************************/
using UnityEngine;
using System.Collections;

namespace CircularGravityForce
{
    public class RocketExplosion : MonoBehaviour
    {
        private CircularGravity cgf;
        private Timer timer;

        // Use this for initialization
        void Start()
        {
            cgf = this.GetComponent<CircularGravity>();
            timer = this.GetComponent<Timer>();
        }

        // Update is called once per frame
        void Update()
        {
            cgf.Enable = !timer.Alarm;
        }
    }
}
