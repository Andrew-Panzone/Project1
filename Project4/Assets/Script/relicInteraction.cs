using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class relicInteraction : MonoBehaviour
{
    public GameObject guidePrefab; 
    public float speed = 5f; 

    private GameObject guideInstance; 

    private Transform ritualSite; 


    public Text interactText;

   
    public float inspectDistance = 5f;
    private bool isInRange = false;


    private void Start()
    {
        ritualSite = GameObject.FindGameObjectWithTag("ritualsite").transform;
        if (ritualSite != null)
        {
            Debug.Log("Ritual site found: " + ritualSite.gameObject.name);
        }
        else
        {
            Debug.LogError("Failed to find ritual site with tag 'ritualsite'.");
        }

        interactText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            Debug.Log("E key was pressed and player is in range.");
            //set the ghost 
            
            guideInstance = Instantiate(guidePrefab, transform.position, Quaternion.identity);
             
        }

        //move toward ritualsite
        if (guideInstance != null)
        {
            MoveGuideTowardsRitualSite();
        }
    }

    private void MoveGuideTowardsRitualSite()
    {
        if (guideInstance != null && ritualSite != null)
        {
            guideInstance.transform.position = Vector3.MoveTowards(
                guideInstance.transform.position,
                ritualSite.position,
                speed * Time.deltaTime
            );

            if (Vector3.Distance(guideInstance.transform.position, ritualSite.position) < 0.1f)
            {
                Destroy(guideInstance);
            }
        }
        else
        {
            Debug.LogError("guideInstance or ritualSite is null.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Vector3.Distance(transform.position, other.transform.position) <= inspectDistance)
            {
                interactText.gameObject.SetActive(true);
                isInRange = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactText.gameObject.SetActive(false);
            isInRange = false;
        }
    }
}
