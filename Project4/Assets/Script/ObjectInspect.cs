using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInspect : MonoBehaviour
{
    //object
    public Transform objectToInspect;

    //trigger distance
    public float inspectDistance = 5f;


    public float scale = 2.0f;

    //press E to inspect
    public Text inspectText;

    private bool isInRange = false;
    private Vector3 originalPosition;
    private Vector3 originalScale;
    private bool isInspecting = false;

    void Start()
    {
        inspectText.gameObject.SetActive(false);
        originalPosition = objectToInspect.position;
        originalScale = objectToInspect.localScale;
    }

    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!isInspecting)
            {
                StartInspecting();
            }
            else
            {
                StopInspecting();
            }
        }
    }

    void StartInspecting()
    {
        objectToInspect.position = Camera.main.transform.position + Camera.main.transform.forward * 2;
        objectToInspect.localScale *= scale; 
        inspectText.gameObject.SetActive(false);
        isInspecting = true;
        Camera.main.GetComponent<MouseLook>().ToggleInspectMode(true);
    }

    void StopInspecting()
    {
        objectToInspect.position = originalPosition;
        objectToInspect.localScale = originalScale;
        isInspecting = false;
        Camera.main.GetComponent<MouseLook>().ToggleInspectMode(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            if (Vector3.Distance(transform.position, other.transform.position) <= inspectDistance)
            {
                inspectText.gameObject.SetActive(true);
                isInRange = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inspectText.gameObject.SetActive(false);
            isInRange = false;
        }
    }
}