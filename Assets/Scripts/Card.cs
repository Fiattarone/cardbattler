using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Card : MonoBehaviour {
	public CardScriptableObject cardSO;
	
	public int currentHealth, attackPower, manaCost;

	public TMP_Text healthText, attackText, costText, nameText, actionDescriptionText, loreText;

	public Image charArt, bgArt;

	private Vector3 targetPoint;
	private Quaternion targetRot;

	public float moveSpeed = 4f, rotateSpeed = 540f;

	public bool inHand;
	public int handPosition;

	private HandController theHC;

    // Start is called before the first frame update
    void Start() {
        SetupCard();

		theHC = FindObjectOfType<HandController>();
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
    void Update() {
        transform.position = Vector3.Lerp(transform.position, targetPoint, moveSpeed * Time.deltaTime);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotateSpeed * Time.deltaTime);
    }

	public void MoveToPoint(Vector3 pointToMoveTo, Quaternion rotToMatch) {
		targetPoint = pointToMoveTo;
		targetRot = rotToMatch;
	}

	private void OnMouseOver() {
		if (inHand) {
			MoveToPoint(theHC.cardPositions[handPosition] + new Vector3(0f, 1f, 0.5f), Quaternion.identity);
		}
	}

	private void OnMouseExit() {
		if (inHand) {
			MoveToPoint(theHC.cardPositions[handPosition], theHC.minPos.rotation);
		}
	}
}
