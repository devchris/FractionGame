/*******************************************************************************************
* Author: Lane Gresham, AKA LaneMax
* Websites: http://resurgamstudios.com
* Version: 3.10
* Created Date: 08-23-15 
* Last Updated: 08-23-15
* Description: Timer
*******************************************************************************************/
using UnityEngine;
using System.Collections;

namespace CircularGravityForce
{
    public class Timer : MonoBehaviour
    {
        [SerializeField]
        private bool startTimer = false;
        public bool StartTimer
        {
            get { return startTimer; }
            set { startTimer = value; }
        }

        [SerializeField]
        private float time = 8f;
        public float Time
        {
            get { return time; }
            set { time = value; }
        }

        [SerializeField]
        public float countdown = 0f;
        public float Countdown
        {
            get { return countdown; }
            set { countdown = value; }
        }

        [SerializeField]
        private bool alarm = false;
        public bool Alarm
        {
            get { return alarm; }
            set { alarm = value; }
        }

        private float timeStamp = 0f;

        // Use this for initialization
        void Start()
        {
            //Resets Timer
            timeStamp = 0f;
        }

        // Update is called once per frame
        void Update()
        {
            if (StartTimer && !Alarm)
            {
                if (Time > Countdown)
                {
                    Alarm = false;

                    if (timeStamp == 0)
                    {
                        timeStamp = UnityEngine.Time.time;
                    }

                    Countdown = (UnityEngine.Time.time - timeStamp);
                }
                else
                {
                    StartTimer = false;
                    Alarm = true;
                }
            }
            else
            {
                Countdown = 0f;
                timeStamp = 0f;
            }
        }
    }
}