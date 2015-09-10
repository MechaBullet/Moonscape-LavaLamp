using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	private bool paused = false;
	Transform heldObject = null;
	Transform vehicle = null;
	Text observableText;
	public bool inGrav = true;
	private UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController controller;
	private Vector3 lastGroundedPosition;

	void Awake() {	
		inGrav = true;
		observableText = GameObject.Find("Canvas/ObservableText").GetComponent<Text>();
		controller = GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>();
	}

	// Update is called once per frame
	void Update () {
		if(inGrav) {
			GetComponent<Rigidbody>().AddForce(Physics.gravity);
		}

		if(!paused) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}
		else {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		if(Input.GetButtonDown("Fire1")) {
			if (heldObject == null) {
				PickUp();
			}
			else Place();
		}

		if(heldObject != null) {
			heldObject.transform.position = transform.Find("ItemSlot").position;
		}

		if(Input.GetKeyDown(KeyCode.Escape)) {
			paused = !paused;
		}

		if(vehicle != null) {
			transform.position = vehicle.position - vehicle.right * 2;
		}

		Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 3, 1 << LayerMask.NameToLayer("Observable"))) {
			observableText.text = hit.transform.name;
		}
		else observableText.text = ".";
	}

	void PickUp() {
		Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 3)) {
			if(hit.transform.tag == "Grabbable") {
				heldObject = hit.transform;
				//Check to make sure the node is not attached to anything
				if(hit.transform.name.StartsWith("Power Node")) {
					Collider[] objects = Physics.OverlapSphere(transform.position, 5.0f);
					for(int i = 0; i < objects.Length; i++) {
						if(objects[i].transform.tag == "Terminal") {
							if(objects[i].GetComponent<Terminal>().node == hit.transform) {
								//objects[i].GetComponent<Terminal>().node = null;
								objects[i].GetComponent<Terminal>().SetOff();
							}
						}
					}
				}
			}
			if(hit.transform.GetComponent<Dialog>() && !GameObject.FindGameObjectWithTag("Dialog").GetComponent<Image>().IsActive()) {
				GameObject.FindGameObjectWithTag("Dialog").GetComponent<DialogManager>().StartDialog(hit.transform.GetComponent<Dialog>().dialogText);
			}
		}
	}

	void Place() {
		Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit, 3)) {
			if(hit.transform.tag == "Terminal" && heldObject.name.StartsWith("Power Node")) {
				hit.transform.GetComponent<Terminal>().SetOn(heldObject);
			}
		}
		heldObject = null;
	}

/*	void EnterVehicle(Transform targetVehicle) {
		vehicle = targetVehicle;
		//Turn off player controls
		GetComponent<Rigidbody>().isKinematic = true;
		GetComponent<CapsuleCollider>().enabled = false;
		GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().enabled = false;
		transform.Find("MainCamera").gameObject.SetActive(false);
		transform.Find("Capsule").gameObject.SetActive(false);

		//Turn on vehicle controls
		vehicle.GetComponent<UnityStandardAssets.Vehicles.Car.CarUserControl>().enabled = true;
		multicam.SetActive(true);
	}

	void ExitVehicle() {
		//Turn on player controls
		GetComponent<Rigidbody>().isKinematic = false;
		GetComponent<CapsuleCollider>().enabled = true;
		GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().enabled = true;
		transform.Find("MainCamera").gameObject.SetActive(true);
		transform.Find("Capsule").gameObject.SetActive(true);
		
		//Turn off vehicle controls
		vehicle.GetComponent<UnityStandardAssets.Vehicles.Car.CarUserControl>().enabled = false;
		multicam.SetActive(false);

		vehicle = null;
	}*/
}
