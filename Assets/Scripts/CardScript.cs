using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardScript : MonoBehaviour {
    private Text textComponent;
    private GameManager gameManager;
    private int cardId;
    private int clickCount;
    public float timeRemaining = 90; // Add this line to store the click count

    public int CardId
    {
        get
        {
            return cardId;
        }

        set
        {
            cardId = value;
        }
    }

    public int ClickCount  // Add this line to expose the click count
    {
        get
        {
            return clickCount;
        }
    }

    void Start () {
        textComponent = gameObject.GetComponentInChildren<Text>();
        clickCount = 0; // Initialize the click count
    }

    public void SetGameManager(GameManager manager)
    {
        gameManager = manager;
    }

    public void OnClicked()
    {
        clickCount++; // Increment the click count
        gameManager.OnCardClicked(cardId);
    }

    public void SetEnable(bool enable)
    {
        gameObject.GetComponent<Button>().interactable = enable;
    }

    public void SetText(string text)
    {
        textComponent.text = text;
    }

    public void ResetText()
    {
        textComponent.text = "?";
    }
     
}