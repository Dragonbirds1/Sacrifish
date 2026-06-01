using UnityEngine;

public class ZoneBoxToggle : MonoBehaviour
{
    public GameObject[] boxesToDisable;

    public GameObject[] boxesToToggle;

    public ZoneBoxToggle[] scriptsToToggle;

    public ZoneBoxToggle[] scriptsToDisable;

    public bool toggle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (toggle)
        {
            foreach (GameObject box in boxesToToggle) 
            {
                box.SetActive(true);
            }
            foreach (ZoneBoxToggle script in scriptsToToggle)
            {
                script.enabled = true;
            }
            foreach (GameObject box in boxesToDisable)
            {
                box.SetActive(false);
            }
            foreach (ZoneBoxToggle script in scriptsToDisable)
            {
                script.enabled = false;
            }
            toggle = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            toggle = true;
        }
    }
}
