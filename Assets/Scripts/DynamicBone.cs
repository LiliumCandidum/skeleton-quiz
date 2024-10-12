

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
    [SerializeField] private RectTransform displayPoint;
    [SerializeField] private Camera camera;

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
        camera.fieldOfView = 90;
        displayPoint.localRotation = UnityEngine.Quaternion.Euler(0, 0, 0);

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
            switch (groupName)
            {
                case "RightArm": // done
                    currentGroup.transform.localPosition = new UnityEngine.Vector3(96, -54, -4);
                    break;
                case "RightLeg": // done
                    currentGroup.transform.localPosition = new UnityEngine.Vector3(70, 52, -12);
                    break;
                case "LeftLeg":
                    currentGroup.transform.localPosition = new UnityEngine.Vector3(41, 51, -14);
                    break;
                case "Body": // done
                    currentGroup.transform.localPosition = new UnityEngine.Vector3(-4, -30, 61);
                    break;
                case "Vertebra":
                    currentGroup.transform.localPosition = new UnityEngine.Vector3(0, -17, -10);
                    break;
                case "Skull":
                    currentGroup.transform.localPosition = new UnityEngine.Vector3(-2, -115, 143);
                    currentGroup.transform.Rotate(new UnityEngine.Vector3(0, 180, 0));
                    break;
                case "RightHand":
                    currentGroup.transform.localPosition = new UnityEngine.Vector3(98, 3, 3);
                    currentGroup.transform.Rotate(new UnityEngine.Vector3(-180, -1, 3));
                    break;
                case "LeftArm":
                    currentGroup.transform.localPosition = new UnityEngine.Vector3(-36, 84, 5);
                    break;
                case "LeftFoot":
                    currentGroup.transform.localPosition = new UnityEngine.Vector3(-15, 43, -134);
                    currentGroup.transform.Rotate(new UnityEngine.Vector3(64, -113, 70));
                    break;
                case "LeftHand":
                    currentGroup.transform.localPosition = new UnityEngine.Vector3(-21, -133, 36);
                    currentGroup.transform.Rotate(new UnityEngine.Vector3(156, -2, -10));
                    break;
                case "RightFoot":
                    currentGroup.transform.localPosition = new UnityEngine.Vector3(-56, -50, -135);
                    currentGroup.transform.Rotate(new UnityEngine.Vector3(59, 65, -116));
                    break;
                case "Rib":
                    currentGroup.transform.localPosition = new UnityEngine.Vector3(-2, -32, 71);
                    break;


            }
            //TODO: Highlight target bone
            //Transform boneToHighlight = currentGroup.transform.GetChild(boneIndex);
            //Renderer boneRenderer = boneToHighlight.GetComponent<Renderer>();
            GameObject currentBone = currentGroup.transform.GetChild(boneIndex).gameObject;

            var outline = currentBone.AddComponent<Outline>();

            outline.OutlineMode = Outline.Mode.OutlineAll;
            outline.OutlineColor = Color.yellow;
            outline.OutlineWidth = 5f;

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
