using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
	public CardScriptableObject cardSO;
	
	public int currentHealth, attackPower, manaCost;

	public TMP_Text healthText, attackText, costText, nameText, actionDescriptionText, loreText;

	public Image charArt, bgArt;
    // Start is called before the first frame update
    void Start()
    {
        SetupCard();
    }

	public void SetupCard()
	{
		currentHealth = cardSO.currentHealth;
		attackPower = cardSO.attackPower;
		manaCost = cardSO.manaCost;

		nameText.text = cardSO.cardName;
		actionDescriptionText.text = cardSO.actionDescription;
		loreText.text = cardSO.cardLore;

		healthText.text = currentHealth.ToString();
		attackText.text = attackPower.ToString();
		costText.text = manaCost.ToString();

		charArt.sprite = cardSO.charSprite;
		bgArt.sprite = cardSO.bgSprite;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
