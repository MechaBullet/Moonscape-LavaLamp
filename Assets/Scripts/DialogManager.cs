using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogManager : MonoBehaviour {
	private string[] textPages;
	private string targetText = "";
	private string currentText = "";
	GameObject text;
	private int page = 0;

	void Awake() {
		text = transform.FindChild("Text").gameObject;
	}

	void Start() {
		ToggleText();
	}

	void Update() {
		if(Input.GetButtonDown("Fire1")) {
			if(targetText == currentText && GetComponent<Image>().IsActive()) {
				if(page == textPages.Length - 1) {
					StartCoroutine(EndDialog());
				}
				else {
					ContinueDialog();
				}
			}
			else if(GetComponent<Image>().IsActive()) {
				currentText = targetText;
				text.GetComponent<Text>().text = currentText;
			}
		}
	}

	public void StartDialog(string[] dialog) {
		if(targetText == "") {
			text.GetComponent<Text>().text = "";
			page = 0;
			textPages = dialog;
			targetText = textPages[page];
			currentText = "";
			StartCoroutine(AddLetter());
			ToggleText();
		}
	}

	public void ContinueDialog() {
		text.GetComponent<Text>().text = "";
		page++;
		targetText = textPages[page];
		currentText = "";
		StartCoroutine(AddLetter());
	}

	public IEnumerator EndDialog() {
		ToggleText();
		yield return new WaitForSeconds(1.0f);
		targetText = "";
		currentText = "";
	}

	IEnumerator AddLetter() {
		yield return new WaitForSeconds(0.05f);
		if(currentText != targetText && targetText != "") {
			currentText = currentText + targetText[currentText.Length];
			text.GetComponent<Text>().text = currentText;
			StartCoroutine(AddLetter());
		}
	}

	public void ToggleText() {
		GetComponent<Image>().enabled = !GetComponent<Image>().IsActive();
		text.SetActive(!text.activeSelf);
	}
}
