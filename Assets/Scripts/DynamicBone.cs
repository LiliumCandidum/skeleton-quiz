

using System;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using UnityEngine;

public class DynamicBone : MonoBehaviour
{

    private GameObject currentGroup;

    private string[] MACRO_GROUPS = { "Skull", "Body", "LeftArm", "RightArm", "LeftLeg", "RightLeg" };    // Five macro groups of bones: Skull, Body, LeftArm, RightArm, LeftLeg, RightLeg
    private string[] SUB_GROUPS = { "Vertebra", "Rib", "LeftHand", "RightHand", "LeftFoot", "RightFoot" };    // Five macro groups of bones: Skull, Body, LeftArm, RightArm, LeftLeg, RightLeg
    [SerializeField] private GameObject[] prefabGroups;
    [SerializeField] private Transform displayPoint;

    void Start()
    {
        NextBone();

    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            NextBone();

        }
    }

    private void NextBone()
    {
        if (currentGroup != null)
        {
            Destroy(currentGroup);
        }

        int layerUI = LayerMask.NameToLayer("UI");

        // pick one of the five macrogroups
        int groupIndex = UnityEngine.Random.Range(0, prefabGroups.Length);

        if (prefabGroups[groupIndex] != null)
        {
            GameObject group = prefabGroups[groupIndex];
            Debug.Log(group.name);

            // pick a bone or a subgroup of bones inside the macrogroup 
            int boneIndex = UnityEngine.Random.Range(0, group.transform.childCount);
            GameObject bone = group.transform.GetChild(boneIndex).gameObject;
            Debug.Log(bone.name);

            // if is a subgroup, we must pick again another bone inside the subgroup
            if (SUB_GROUPS.Contains(bone.name))
            {
                group = bone;
                boneIndex = UnityEngine.Random.Range(0, group.transform.childCount);
                bone = group.transform.GetChild(boneIndex).gameObject;
                Debug.Log(bone.name);
            }

            // instantiate the group
            currentGroup = Instantiate(group, displayPoint.position, UnityEngine.Quaternion.identity);

            //Rotate on display point should work
            currentGroup.transform.SetParent(displayPoint);

            //check which group it is to fix x,y,z relative to parent
            string groupName = group.name;
            switch(groupName) {
                case "RightArm":
                    currentGroup.transform.localPosition = new UnityEngine.Vector3(95,-55, -29);
                    break;
                case "RightLeg": 
                    currentGroup.transform.localPosition = new UnityEngine.Vector3(32,51,-42);
                    break;
                case "LeftLeg":
                    currentGroup.transform.localPosition = new UnityEngine.Vector3(32, 51, -42);
                    break;
                case "Body":
                    currentGroup.transform.localPosition = new UnityEngine.Vector3(-4, -22, 45);
                    break;
                case "Vertebra":
                    currentGroup.transform.localPosition = new UnityEngine.Vector3(0, -17, -26);
                    break;
                case "Skull":
                    currentGroup.transform.localPosition = new UnityEngine.Vector3(-2, -115, 111);
                    currentGroup.transform.Rotate(new UnityEngine.Vector3(0,180,0));
                    break;
                case "RightHand": 
                    currentGroup.transform.localPosition = new UnityEngine.Vector3(106, 6,-22);
                    currentGroup.transform.Rotate(new UnityEngine.Vector3(-180,-1,3));
                    break;
                case "LeftArm":
                    currentGroup.transform.localPosition = new UnityEngine.Vector3(-36, 84, 0);
                    break;
                case "LeftFoot":
                    currentGroup.transform.localPosition = new UnityEngine.Vector3(-18, 54, -154);
                    currentGroup.transform.Rotate(new UnityEngine.Vector3(64,-113,70));
                    break;
                case "LeftHand":
                    currentGroup.transform.localPosition = new UnityEngine.Vector3(-21, -133, 11);
                    currentGroup.transform.Rotate(new UnityEngine.Vector3(156,-2,-10));
                    break;
                case "RightFoot":
                    currentGroup.transform.localPosition = new UnityEngine.Vector3(-64, -50, -154);
                    currentGroup.transform.Rotate(new UnityEngine.Vector3(59,65,-116));
                    break;
                case "Rib":
                    currentGroup.transform.localPosition = new UnityEngine.Vector3(13, -128, 924);
                    break;
 
                
            }
            //TODO: Highlight target bone
            Transform boneToHighlight = currentGroup.transform.GetChild(boneIndex);
            Renderer boneRenderer = boneToHighlight.GetComponent<Renderer>();
            
            // Set UI layer
            currentGroup.layer = layerUI;
            foreach (Transform child in currentGroup.GetComponentsInChildren<Transform>(true))  
            {
               child.gameObject.layer = layerUI;
            }

        }





        //currentGroup = Instantiate(prefabGroups[0], displayPoint.localPosition, Quaternion.identity);

        //currentGroup.transform.locallocalPosition = new Vector3(0, 0, 0);
        //currentGroup.transform.SetParent(displayPoint);

        // Set localPosition
        //currentGroup.transform.locallocalPosition = new Vector3(0, 0, 0);
        // Set rotation
        //currentGroup.transform.rotation = new Vector3(43.296f, 6.468f, 0.395f);
        // Set scale
        //currentGroup.transform.localScale = new Vector3(0.5365187f, 0.5365187f, 0.51f);
    }

    // private void SpawnBone()
}
