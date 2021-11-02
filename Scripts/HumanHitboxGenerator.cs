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

		[Header("Component Field Tools")]
		[InspectorButton(nameof(FillBoneTransforms))]
		public bool btnFillBoneTransforms;

		[Header("Hitboxes Tools")]
		[InspectorButton(nameof(DestroyAllHitBoxComponents))]
		public bool destroyAllHitBoxComponents;
		[InspectorButton(nameof(DestroyAllHitBoxGameObjects))]
		public bool destroyAllHitBoxGameObjects;

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

		public void DestroyAllHitBoxComponents()
        {
			if (root == null)
			{
				EditorUtility.DisplayDialog("Error", "No root transform assigned", "OK");
				return;
			}

			DamageableHitBox[] hitboxes = root.GetComponentsInChildren<DamageableHitBox>();
			for (int i = hitboxes.Length - 1; i >= 0; --i)
            {
				GameObject hitBoxesObj = hitboxes[i].gameObject;
				Rigidbody rb = hitBoxesObj.GetComponent<Rigidbody>();
				if (rb != null)
					Destroy(rb);
				Rigidbody2D rb2 = hitBoxesObj.GetComponent<Rigidbody2D>();
				if (rb2 != null)
					Destroy(rb2);
				Collider col = hitBoxesObj.GetComponent<Collider>();
				if (col != null)
					Destroy(col);
				Collider2D col2 = hitBoxesObj.GetComponent<Collider2D>();
				if (col2 != null)
					Destroy(col2);
				Destroy(hitboxes[i]);
			}
        }

		public void DestroyAllHitBoxGameObjects()
		{
			if (root == null)
			{
				EditorUtility.DisplayDialog("Error", "No root transform assigned", "OK");
				return;
			}

			DamageableHitBox[] hitboxes = root.GetComponentsInChildren<DamageableHitBox>();
			for (int i = hitboxes.Length - 1; i >= 0; --i)
			{
				Destroy(hitboxes[i].gameObject);
			}
		}
	}
}
#endif
