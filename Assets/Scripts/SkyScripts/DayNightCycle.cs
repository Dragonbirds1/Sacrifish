using UnityEngine;
using UnityEngine.Rendering;

public class DayNightCycle : MonoBehaviour
{

    public float dayDuration; // = 120f; // Duration of a full day in seconds
    public float nightDuration; // = 120f; // Duration of a full night in seconds
    public float transitionDuration; // = 5f; // Duration of the transition between day and night
    public float currentTime = 0f; // Current time in the cycle
    public float transitionTime = 0f;
    public float currentExposure; // Current exposure level of the skybox

    public bool isDay = true; // Flag to track whether it's currently day or night
    public bool isTransitioning = false; // Flag to track whether a transition is currently happening
    public bool startTransition = false; // Flag to trigger the start of the transition

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Exposure", currentExposure);

        if (!isTransitioning)
        {
            currentTime += Time.deltaTime;
        }

        if (currentTime >= dayDuration && isDay)
        {
            isTransitioning = true;
            currentTime = 0f;
        }

        if (currentTime >= nightDuration && !isDay)
        {
            isTransitioning = true;
            currentTime = 0f;
        }

        if (isTransitioning)
        {
            // Make the skybox exposure transition smoothly between day and night
            if (isDay)
            {
                currentExposure -= Time.deltaTime;
                if (currentExposure <= 0.02f)
                {
                    currentExposure = 0.02f;
                    isTransitioning = false;
                    isDay = !isDay; // Toggle between day and night
                    transitionTime = 0f;
                }
            }
            else if (!isDay)
            {
                currentExposure += Time.deltaTime;
                if (currentExposure >= 0.5f)
                {
                    currentExposure = 0.5f;
                    isTransitioning = false;
                    isDay = !isDay; // Toggle between day and night
                    transitionTime = 0f;
                }
            }
            //RenderSettings.skybox.SetFloat("_Exposure", Mathf.Lerp(isDay ? 0.05f : 4f, isDay ? 4f : 0.05f, currentTime / transitionDuration));
        }
    }
}
