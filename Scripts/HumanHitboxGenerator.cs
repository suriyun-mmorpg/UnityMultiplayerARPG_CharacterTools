#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MultiplayerARPG
{
	public class HumanHitboxGenerator : MonoBehaviour
    {
        [Header("Bones Transform")]
        public Animator targetAnimator;
		public Transform root;
		public Transform hips;
		public Transform spine;
		public Transform chest;
		public Transform head;
		public Transform leftUpperLeg;
		public Transform leftLowerLeg;
		public Transform leftFoot;
		public Transform rightUpperLeg;
		public Transform rightLowerLeg;
		public Transform rightFoot;
		public Transform leftUpperArm;
		public Transform leftLowerArm;
		public Transform leftHand;
		public Transform rightUpperArm;
		public Transform rightLowerArm;
		public Transform rightHand;

		[Header("Tools")]
		[InspectorButton(nameof(FillBoneTransforms))]
		public bool btnFillBoneTransforms;

		public void FillBoneTransforms()
        {
			if (targetAnimator == null)
            {
				EditorUtility.DisplayDialog("Error", "You have to choose target animator", "OK");
				return;
            }

			if (!targetAnimator.isHuman)
			{
				EditorUtility.DisplayDialog("Error", "Target animator must be humanoid", "OK");
				return;
			}

			root = targetAnimator.transform;
			hips = targetAnimator.GetBoneTransform(HumanBodyBones.Hips);
			spine = targetAnimator.GetBoneTransform(HumanBodyBones.Spine);
			chest = targetAnimator.GetBoneTransform(HumanBodyBones.Chest);
			head = targetAnimator.GetBoneTransform(HumanBodyBones.Head);
			leftUpperArm = targetAnimator.GetBoneTransform(HumanBodyBones.LeftUpperArm);
			leftLowerArm = targetAnimator.GetBoneTransform(HumanBodyBones.LeftLowerArm);
			leftHand = targetAnimator.GetBoneTransform(HumanBodyBones.LeftHand);
			rightUpperArm = targetAnimator.GetBoneTransform(HumanBodyBones.RightUpperArm);
			rightLowerArm = targetAnimator.GetBoneTransform(HumanBodyBones.RightLowerArm);
			rightHand = targetAnimator.GetBoneTransform(HumanBodyBones.RightHand);
			leftUpperLeg = targetAnimator.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
			leftLowerLeg = targetAnimator.GetBoneTransform(HumanBodyBones.LeftLowerLeg);
			leftFoot = targetAnimator.GetBoneTransform(HumanBodyBones.LeftFoot);
			rightUpperLeg = targetAnimator.GetBoneTransform(HumanBodyBones.RightUpperLeg);
			rightLowerLeg = targetAnimator.GetBoneTransform(HumanBodyBones.RightLowerLeg);
			rightFoot = targetAnimator.GetBoneTransform(HumanBodyBones.RightFoot);
		}
	}
}
#endif
