using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBone : MonoBehaviour
{
    public GameObject[] objectsToChooseFrom;
    public Transform displayPoint;
    private GameObject currentObject;

    private string[] prefabNames = {"FJ3201_BP22977_FMA52749_Hyoid bone", "FJ3392_BP23110_FMA52892_Right zygomatic bone", "FJ6471_BP24091_FMA53655_Right palatine bone"};

    void Start()
    {
        objectsToChooseFrom = new GameObject[prefabNames.Length];

        for(int i=0; i < prefabNames.Length; i++)
        {
            objectsToChooseFrom[i] = GameObject.Find(prefabNames[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentObject != null)
            {
                Destroy(currentObject);
            }

            int layerUI = LayerMask.NameToLayer("UI");
            int randomNumber = Random.Range(0, 3);

            currentObject = Instantiate(objectsToChooseFrom[randomNumber], displayPoint.position, Quaternion.identity);
            currentObject.transform.SetParent(displayPoint);
            // Set UI layer
            currentObject.layer = layerUI;
            foreach (Transform child in currentObject.GetComponentsInChildren<Transform>(true))  
            {
               child.gameObject.layer = layerUI;
            }
            // Set position
            currentObject.transform.localPosition = new Vector3(6.4f, 58.6f, -784f);
            // Set rotation
            // currentObject.transform.rotation = new Vector3(43.296f, 6.468f, 0.395f);
            // Set scale
            currentObject.transform.localScale = new Vector3(0.5365187f, 0.5365187f, 0.51f);
        }        
    }
}
