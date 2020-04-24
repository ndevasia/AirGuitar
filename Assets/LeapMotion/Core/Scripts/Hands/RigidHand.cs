/******************************************************************************
 * Copyright (C) Leap Motion, Inc. 2011-2018.                                 *
 * Leap Motion proprietary and confidential.                                  *
 *                                                                            *
 * Use subject to the terms of the Leap Motion SDK Agreement available at     *
 * https://developer.leapmotion.com/sdk_agreement, or another agreement       *
 * between Leap Motion and you, your company or other organization.           *
 ******************************************************************************/

using UnityEngine;
using System.Collections;
using Leap;

namespace Leap.Unity {
  /** A physics model for our rigid hand made out of various Unity Collider. */
  public class RigidHand : SkeletalHand {
        //globals go here
    public string strum = "NOT PLAYING";
    public float diff = 0.06f;
    public float height = 20f;
    public GameObject AMajor;
    public GameObject CMajor;
    public override ModelType HandModelType {
      get {
        return ModelType.Physics;
      }
    }
    public float filtering = 0.5f;

    public override bool SupportsEditorPersistence() {
      return true;
    }

    public override void InitHand() {
      base.InitHand();
    }

    public override void UpdateHand() {
       if (height == 20f)
            {
                height = hand_.GetPalmPose().position.y;
            }

            //float grabThreshold = 0.5f;
       //Debug.Log(hand_.GetPalmPose().position.y);
       float current_pos = hand_.GetPalmPose().position.y;
       
       if (current_pos - height > diff)
            {
                height = current_pos;
                AMajor.SetActive(true);
                AMajor.GetComponent<AudioSource>().Play();
                Debug.Log("UPSTRUM");
            }
       else if (current_pos-height < - diff)
            {
                height = current_pos;
                CMajor.SetActive(true);
                CMajor.GetComponent<AudioSource>().Play();
                Debug.Log("DOWNSTRUM");
            }

/*
      float velocityThreshold = 1;
      float[] velocities = hand_.PalmVelocity.ToFloatArray();
      //float grab = hand_.GrabStrength;
      Debug.Log("POSITION" + hand_.GetPalmPose());
      //Debug.Log("VELOCITY" + hand_.PalmVelocity.ToFloatArray());
      
      if (velocities[1] < - velocityThreshold) {
        if (!strum.Equals("DOWNSTRUM")) {
             strum = "DOWNSTRUM";
             //Debug.Log(strum);
        }
      } else if (velocities[1] > velocityThreshold) {
        if (!strum.Equals("UPSTRUM")){
            strum = "UPSTRUM";
            //Debug.Log(strum);
        }
       } else {
           if (!strum.Equals("NOT PLAYING")) {
                strum = "NOT PLAYING";
                //Debug.Log(strum);
           }
     }
     */
       

      for (int f = 0; f < fingers.Length; ++f) {
        if (fingers[f] != null) {
          fingers[f].UpdateFinger();
          // Debug.Log(fingers[f].name + "  " + fingers[f].GetTipPosition());
                }
      }

      if (palm != null) {
        Rigidbody palmBody = palm.GetComponent<Rigidbody>();
        if (palmBody) {
          palmBody.MovePosition(GetPalmCenter());
          palmBody.MoveRotation(GetPalmRotation());
        } else {
          palm.position = GetPalmCenter();
          palm.rotation = GetPalmRotation();
        }
      }

      if (forearm != null) {
        // Set arm dimensions.
        CapsuleCollider capsule = forearm.GetComponent<CapsuleCollider>();
        if (capsule != null) {
          // Initialization
          capsule.direction = 2;
          forearm.localScale = new Vector3(1f / transform.lossyScale.x, 1f / transform.lossyScale.y, 1f / transform.lossyScale.z);

          // Update
          capsule.radius = GetArmWidth() / 2f;
          capsule.height = GetArmLength() + GetArmWidth();
        }

        Rigidbody forearmBody = forearm.GetComponent<Rigidbody>();
        if (forearmBody) {
          forearmBody.MovePosition(GetArmCenter());
          forearmBody.MoveRotation(GetArmRotation());
        } else {
          forearm.position = GetArmCenter();
          forearm.rotation = GetArmRotation();
        }
      }
    }
  }
}
