/******************************************************************************\
* Copyright (C) Leap Motion, Inc. 2011-2014.                                   *
* Leap Motion proprietary. Licensed under Apache 2.0                           *
* Available at http://www.apache.org/licenses/LICENSE-2.0.html                 *
\******************************************************************************/
// Original script: "MagneticPinch.cs" modified by unitycoder.com to just get the finger position & directions

using UnityEngine;
using System.Collections;
using Leap;


namespace Leap.Unity
{

    public class GetLeapFingers : MonoBehaviour
    {
       
        public HandModel hand_model;
        public Hand leap_hand;

        void Awake()
        {
         
            hand_model = GetComponent<HandModel>();
            leap_hand = hand_model.GetLeapHand();
            if (leap_hand == null) Debug.LogError("No leap_hand founded");
            
        }

        void Update()
        {
            for (int i = 0; i < hand_model.fingers.Length; i++)
            {
                FingerModel finger = hand_model.fingers[i];
                // draw ray from finger tips (enable Gizmos in Game window to see)
                Debug.DrawRay(finger.GetTipPosition(), finger.GetRay().direction, Color.red);
            }
        }
    }

}