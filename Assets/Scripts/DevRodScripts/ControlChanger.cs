using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ControlChanger : MonoBehaviour
{
    public TMP_InputField inputField;

    public float numberTyped;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputField.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    public void ValueChangeCheck()
    {
        if (float.TryParse(inputField.text, out float result))
        {
            if (result <= 1068f)
            {
                numberTyped = result;
                Debug.Log("Parsed number: " + numberTyped);
            }
            else if (result > 1068f)
            {
                numberTyped = 1068f;
                Debug.Log("Parsed number exceeds maximum. Set to 1068: " + numberTyped);
            }
        }
        else
        {
            Debug.LogWarning("Invalid input. Please enter a valid number.");
        }
    }
}
