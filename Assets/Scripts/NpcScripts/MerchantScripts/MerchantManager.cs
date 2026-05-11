using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class MerchantManager : MonoBehaviour
{
    public PlayerMotor playerMotor;
    public CatchFish catchFish;
    public TextMeshProUGUI merchantLines;
    public KeyCode toggleKey;
    public float typingSpeed = 0.05f; // Speed at which the NPC "types" the response.
    public bool isResponding;
    public int timeTillNextResponses = 0; // Time in seconds until the NPC can respond again.
    public int maxTimeTillNextResponses = 10; // Max time in seconds until the NPC can respond again.
    public string npcName = "NPC";
    // Run the chatbot like chatGPT or other similar systems.
    public string chatBotSystem = "DefaultChatBot";
    public string currentConversation = "";
    public string lastPlayerInput = "";
    public string lastNpcResponse = "";
    //public float responseDelay = 1.0f; // Delay in seconds before the NPC responds.
    public bool sellFishInHand, sellAllFish, goodBye, fishInHand, haveFish;
    public GameObject sellFishInHandButton, sellAllFishButton, goodByeButton, background, backgroundMerchant, player;
    public float timeTillRemoveText = 1f; // Time in seconds until the NPC's dialogue text is removed after displaying a response.
    public float distanceToTalk; // The distance the player needs to be within to talk to the NPC.
    public bool isRemovingText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sellFishInHandButton.SetActive(false);
        sellAllFishButton.SetActive(false);
        goodByeButton.SetActive(false);
        background.SetActive(false);
        backgroundMerchant.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= distanceToTalk)
        {
            if (Input.GetKeyDown(toggleKey) && !isResponding)
            {
                isResponding = true;
                sellFishInHand = false;
                sellAllFish = false;
                goodBye = false;
                backgroundMerchant.SetActive(true);
                GenerateNpcResponse();
            }
        }
        else if (Vector3.Distance(player.transform.position, transform.position) > distanceToTalk)
        {
            if (isResponding)
            {
                // Debug the bye later
            }
        }

        if (timeTillNextResponses > 0)
        {
            timeTillNextResponses -= 1;
            if (timeTillNextResponses <= 0)
            {
                isRemovingText = true;
            }
        }

        if (isRemovingText)
        {
            timeTillRemoveText -= Time.deltaTime;
            if (timeTillRemoveText <= 0)
            {
                merchantLines.text = "";
                isRemovingText = false;
                timeTillRemoveText = 1f;
                backgroundMerchant.SetActive(false);
            }
        }
    }

    void GenerateNpcResponse()
    {

        // Make string response = CallChatBotSystem(prompt);
        char[] chars = { ' ', '\t', '\r', '\n' };
        string[] conversationHistory = currentConversation.Split(chars, System.StringSplitOptions.RemoveEmptyEntries);
        // Now make the responce.
        string prompt = chatBotSystem + "\n" + string.Join("\n", conversationHistory) + "\nPlayer: " + lastPlayerInput + "\n" + npcName + ":";
        string CallChatBotSystem(string prompt)
        {
            // This function will call the chatBotSystem with the given prompt and return the response.
            // This is a placeholder implementation and should be replaced with actual API calls to the chatBotSystem.
            // lets now make the response more ai like by adding some randomness and variation to it.
            if (sellFishInHand)
            {
                if (fishInHand)
                {
                    return "Pleasure doing buiness with you.";
                }
                else
                {
                    return "It seems you don't have any fish in your hand. Please pull out the fish you want to sell.";
                }
            }
            else if (sellAllFish)
            {
                if (haveFish)
                {
                    catchFish.SellAllFish();
                    return "Pleasure doing buisness with you.";
                }
                else
                {
                    return "It seems you don't have any fish to sell. Please catch some fish before trying to sell them.";
                }
            }
            else if (goodBye)
            {
                return "Thank you for visiting my shop. Have a great day!";
            }
            else
            {
                return "Welcome to my shop! How can I help you today?";
            }
        }

        string response = CallChatBotSystem(prompt);

        DisplayNpcResponse(response);
    }

    void DisplayNpcResponse(string response)
    {
        // Display the NPC's response with typing effect.
        // Here we can use a coroutine to simulate typing.
        StartCoroutine(TypeResponce(response));
        // Make the NPC dialogue text visible and update it.
        merchantLines.gameObject.SetActive(true);
        merchantLines.text = "";


    }

    IEnumerator TypeResponce(string response)
    {
        // Make the NPC "type" the response character by character.
        // Make sure to update the NPC dialogue text with each character.
        string displayedText = "";
        foreach (char c in response)
        {
            displayedText += c;
            // Update the NPC's dialogue UI here with displayedText.
            merchantLines.text = displayedText;
            yield return new WaitForSeconds(typingSpeed);
        }
        isResponding = false;
        timeTillNextResponses = maxTimeTillNextResponses;
        if (!sellFishInHand && !sellAllFish && !goodBye)
        {
            playerMotor.showCursor = true;
            sellFishInHandButton.SetActive(true);
            sellAllFishButton.SetActive(true);
            goodByeButton.SetActive(true);
            background.SetActive(true);
        }
    }

    public void SellFishInHand()
    {
        isResponding = true;
        sellFishInHand = true;
        sellFishInHandButton.SetActive(false);
        sellAllFishButton.SetActive(false);
        goodByeButton.SetActive(false);
        background.SetActive(false);
        backgroundMerchant.SetActive(true);
        GenerateNpcResponse();
    }
    public void SellAllFish()
    {
        isResponding = true;
        sellAllFish = true;
        sellAllFishButton.SetActive(false);
        sellFishInHandButton.SetActive(false);
        goodByeButton.SetActive(false);
        background.SetActive(false);
        backgroundMerchant.SetActive(true);
        GenerateNpcResponse();
    }
    
    public void GoodBye()
    {
        isResponding = true;
        goodBye = true;
        goodByeButton.SetActive(false);
        sellFishInHandButton.SetActive(false);
        sellAllFishButton.SetActive(false);
        background.SetActive(false);
        backgroundMerchant.SetActive(true);
        GenerateNpcResponse();
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, distanceToTalk);
    }
}
