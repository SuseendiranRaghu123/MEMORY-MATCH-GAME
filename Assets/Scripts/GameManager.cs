using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {
    public CardScript[] cards;
    public string[]     matchTextsArray;


    private int firstCardId = -1;
    private int secondCardId = -1;
    private bool isWrongMatchShowing;
    private int noofcardclicked = 0;
    private int card0=0,card1=0,card2=0,card3=0,card4=0,card5=0,card6=0,card7=0,card8=0,card9=0;

    [SerializeField]
    private float MaxWrongMatchShowTime = 1.0f;
    private int numOfMatches;
    private float wrongMatchDelayTimer = 0;

    [SerializeField]
    private Button RestartButton;
    public Timer timer ;
    public float ProductiveTime;
    public List<GameObject> cards1 = new List<GameObject>();
    
  void Start () {
        InitCards();
        timer = gameObject.AddComponent<Timer>();

        InitGame();
	}


    private void InitCards()
    {
        int len = cards.Length;
        for (int i = 0; i < len; i++)
        {
            cards[i].CardId = i;
            cards[i].SetGameManager(this);
        }
    }

    private void InitGame()
    {
        numOfMatches = 0;
        

        RestartButton.gameObject.SetActive(false);
        ShuffleItemArray();
    }

    private void ShuffleItemArray()
    {
        int len = matchTextsArray.Length;
        for (int i = 0; i < len-1; i++)
        {
         
            int randId = Random.Range(i, len - 1);

            string temp = matchTextsArray[i];
            matchTextsArray[i] = matchTextsArray[randId];
            matchTextsArray[randId] = temp;
        }
    }

    void Update () {
        if (isWrongMatchShowing)
        {
            wrongMatchDelayTimer -= Time.deltaTime;
            if (wrongMatchDelayTimer < 0)
            {
                isWrongMatchShowing = false;

                
                cards[firstCardId].ResetText();
                cards[secondCardId].ResetText();

                firstCardId = -1;
                secondCardId = -1;
            }
        }
	}

    public void OnCardClicked(int cardId)
    {
        if (isWrongMatchShowing)
        {
            return;
        }

        Debug.Log("User Clicked Card ID = " + cardId);
        noofcardclicked++;
        if (cardId==0){
            card0++;
            Debug.Log("The Card "+cardId+" has been clicked "+card0 + " times");
        }
        if (cardId==1){
            card1++;
            Debug.Log("The Card "+cardId+" has been clicked "+card1 + " times");
        }
        if (cardId==2){
            card2++;
            Debug.Log("The Card "+cardId+" has been clicked "+card2 + " times");
        }
        if (cardId==3){
            card3++;
            Debug.Log("The Card "+cardId+" has been clicked "+card3 + " times");
        }
        if (cardId==4){
            card4++;
            Debug.Log("The Card "+cardId+" has been clicked "+card4 + " times");
        }
        if (cardId==5){
            card5++;
            Debug.Log("The Card "+cardId+" has been clicked "+card5 + " times");
        }
        if (cardId==6){
            card6++;
            Debug.Log("The Card "+cardId+" has been clicked "+card6 + " times");
        }
        if (cardId==7){
            card7++;
            Debug.Log("The Card "+cardId+" has been clicked "+card7 + " times");
        }
        if (cardId==8){
            card8++;
            Debug.Log("The Card "+cardId+" has been clicked "+card8 + " times");
        }
        if (cardId==9){
            card9++;
            Debug.Log("The Card "+cardId+" has been clicked "+card9 + " times");
        }
        
        


        if (firstCardId < 0)
        {
            firstCardId = cardId;   
            cards[cardId].SetText(matchTextsArray[cardId]);
        }
        else
        {
            secondCardId = cardId;
            cards[cardId].SetText(matchTextsArray[cardId]);

            if (matchTextsArray[firstCardId] == matchTextsArray[secondCardId])
            {
                Debug.Log("Cards Correct Match");
                cards[firstCardId].SetEnable(false);
                cards[secondCardId].SetEnable(false);

                firstCardId = -1;
                secondCardId = -1;

                numOfMatches += 1;
                if(numOfMatches >= cards.Length / 2)
                {
                    RestartButton.gameObject.SetActive(true);
                }
            }
            else
            {
                Debug.Log("Cards Wrong Match");
                ResetWrongMatchAfterDelay();
            }
        }
       
    }

    private void ResetWrongMatchAfterDelay()
    {
        isWrongMatchShowing = true;
        wrongMatchDelayTimer = MaxWrongMatchShowTime;
    }
    



    public void RestartGame()
    {
        firstCardId = -1;
        secondCardId = -1;
        Debug.Log("Total Time = "+timer.timeRemaining);
        float noofcardclicked1=(float)noofcardclicked;
        ProductiveTime=timer.timeRemaining-(noofcardclicked1);
        Debug.Log("Not Productive Time = "+ProductiveTime);
        
        Debug.Log("Number of cards clicked "+noofcardclicked);
   
        

        int len = cards.Length;
        for (int i = 0; i < len; i++)
        {
            cards[i].SetEnable(true);
            cards[i].ResetText();
        }

        InitGame();
    }

}
