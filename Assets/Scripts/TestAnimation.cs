using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class TestAnimation : MonoBehaviour {

	// Use this for initialization
	void Start()
    {
        UnityFactory.factory.LoadDragonBonesData("Player/ANIM_COURSE_ske"); // DragonBones file path (without suffix)
        UnityFactory.factory.LoadTextureAtlasData("Player/ANIM_COURSE_tex"); //Texture atlas file path (without suffix) 

        // Create armature.
        var armatureComponent = UnityFactory.factory.BuildArmatureComponent("Player");
        // Input armature name

        // Play animation.
        //armatureComponent.animation.Play("Dead");

        // Change armatureposition.
        armatureComponent.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
    }
}
