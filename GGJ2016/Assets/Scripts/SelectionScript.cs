﻿using UnityEngine;
using System.Collections;

public class SelectionScript : MonoBehaviour {
	
	private string p1a;
	private string p1d;
	private string p1s;
	private string p2a;
	private string p2d;
	private string p2s;
	private bool a1Ready;
	private bool a2Ready;
	private bool d1Ready;
	private bool d2Ready;
	private bool s1Ready;
	private bool s2Ready;
	public bool p1Ready;
	public bool p2Ready;
	public bool allReady;
	public bool CombatEnded = false;

	public int P1DmgTaken = 0;
	public int P2DmgTaken = 0;

	public float P1HP = 100;
	public float P2HP = 100;

	public GameObject projectile1;
	public GameObject projectile2;
	public GameObject totem1;
	public GameObject totem2;

	private float countDown;
	private string[] randomTotem = new string[5] {Const.FIRE, Const.WATER, Const.EARTH, Const.METAL, Const.WOOD};
	private string[] randomAnimal = new string[5] {Const.FOX, Const.DRAGON, Const.TANUKI, Const.ONI, Const.MOOSE};

	public GameObject TimerLabel;
	private UILabel _TimerLabel;

	public GameObject P1HPGO;
	public GameObject P2HPGO;
	private UISlider _P1hp;
	private UISlider _P2hp;

	public GameObject SimulationGO;
	private Simulation simulationScript;

	public GameObject InfoSheet;

	public GameObject MainMenuUi;
	public GameObject CombatUI;
	public GameObject EndGameUI;


	// FIRE -> WOOD -> WATER -> EARTH -> METAL

	// Reset all state to false
	public void Reinitialization() {
		p1a = null;
		p1d = null;
		p1s = null;
		p2a = null;
		p2d = null;
		p2s = null;

		a1Ready = false;
		a2Ready = false;
		d1Ready = false;
		d2Ready = false;
		s1Ready = false;
		s2Ready = false;
		p1Ready = false;
		p2Ready = false;
		allReady = false;

		countDown = 5;
	}


	string chooseRandomTotem () {
		int n = randomTotem.Length;
		return randomTotem[Random.Range (0, n)] ;  

	}

	string chooseRandomAnimal () {
		int n = randomAnimal.Length;
		return randomAnimal[Random.Range (0, n)] ;  
		
	}


	// Use this for initialization
	void Start () {
		Reinitialization (); 

		_TimerLabel = TimerLabel.GetComponent<UILabel>();
		simulationScript = SimulationGO.GetComponent<Simulation>();

		_P1hp = P1HPGO.GetComponent<UISlider>();
		_P2hp = P2HPGO.GetComponent<UISlider>();
	}

	void ShowMainMenuUI () {
		MainMenuUi.SetActive(true);
		CombatUI.SetActive(false);
		EndGameUI.SetActive(false);
	}

	void ShowCombatUI () {
		MainMenuUi.SetActive(false);
		CombatUI.SetActive(true);
		EndGameUI.SetActive(false);
	}

	void ShowEndGameUI () {
		MainMenuUi.SetActive(false);
		CombatUI.SetActive(false);
		EndGameUI.SetActive(true);
	}
		


	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space) && MainMenuUi.activeInHierarchy) {

			ShowCombatUI();

			CombatEnded = true;

		}

		if (Input.GetKeyDown (KeyCode.Space) && EndGameUI.activeInHierarchy) {
			
			ShowMainMenuUI();
			
		}

		if (CombatEnded == true) {

			TimerLabel.SetActive (true);
			InfoSheet.SetActive (true);
			_TimerLabel.text = "" + (Mathf.Round(countDown));
		
			if (!allReady) {

				if (countDown <= 0) {

					TimerLabel.SetActive (false);
					InfoSheet.SetActive(false);

					// randomize totem blocks
					if (p1a == null){
						p1a = chooseRandomTotem (); 
					}
					if (p1d == null) {
						p1d = chooseRandomTotem ();
					}
					if (p1s == null){
						p1s = chooseRandomAnimal (); 
					}
					if (p2a == null) {
						p2a = chooseRandomTotem (); 
					}
					if (p2d == null) {
						p2d = chooseRandomTotem (); 
					}
					if (p2s == null){
						p2s = chooseRandomAnimal (); 
					}

					Debug.Log("P1a: " + p1a + " P2a: " + p2a);
					Debug.Log("P1d: " + p1d + " P2d: " + p2d);
					Debug.Log("P1s: " + p1s + " P2s: " + p2s);

					p1Ready = true;
					p2Ready = true;
				}

				if (countDown > 0) {

					countDown -= Time.deltaTime;

				}

				if (!p1Ready || !p2Ready) {


					// Player 1 Selections
					if(!s1Ready) {
						if (Input.GetKeyDown (KeyCode.Alpha1)) {
							p1s = Const.FOX;
							s1Ready = true;
							simulationScript.p1TotemScript.addPlaceholder();
							print("Player1Support = FOX");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha2)) {
							p1s = Const.MOOSE;
							s1Ready = true;
							simulationScript.p1TotemScript.addPlaceholder();
							print("Player1Support = MOOSE");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha3)) {
							p1s = Const.DRAGON;
							s1Ready = true;
							simulationScript.p1TotemScript.addPlaceholder();
							print("Player1Support = DRAGON");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha4)) {
							p1s = Const.ONI;
							s1Ready = true;
							simulationScript.p1TotemScript.addPlaceholder();
							print("Player1Support = ONI");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha5)) {
							p1s = Const.TANUKI;
							s1Ready = true;
							simulationScript.p1TotemScript.addPlaceholder();
							print("Player1Support = TANUKI");
						}
						
					} else if(!d1Ready) {
						if (Input.GetKeyDown (KeyCode.Alpha1)) {
							p1d = Const.FIRE;
							d1Ready = true;
							simulationScript.p1TotemScript.addPlaceholder();
							print("Player1Defense = FIRE");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha2)) {
							p1d = Const.WOOD;
							d1Ready = true;
							simulationScript.p1TotemScript.addPlaceholder();
							print("Player1Defense = WOOD");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha3)) {
							p1d = Const.WATER;
							d1Ready = true;
							simulationScript.p1TotemScript.addPlaceholder();
							print("Player1Defense = WATER");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha4)) {
							p1d = Const.METAL;
							d1Ready = true;
							simulationScript.p1TotemScript.addPlaceholder();
							print("Player1Defense = METAL");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha5)) {
							p1d = Const.EARTH;
							d1Ready = true;
							simulationScript.p1TotemScript.addPlaceholder();
							print("Player1Defense = EARTH");
						}

					}else if (!a1Ready) {
						if (Input.GetKeyDown (KeyCode.Alpha1)) {
							p1a = Const.FIRE;
							a1Ready = true;
							p1Ready = true;
							simulationScript.p1TotemScript.addPlaceholder();
							print("Player1Attack = FIRE, Player 1 Ready");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha2)) {
							p1a = Const.WOOD;
							a1Ready = true;
							p1Ready = true;
							simulationScript.p1TotemScript.addPlaceholder();
							print("Player1Attack = WOOD, Player 1 Ready");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha3)) {
							p1a = Const.WATER;
							a1Ready = true;
							p1Ready = true;
							simulationScript.p1TotemScript.addPlaceholder();
							print("Player1Attack = WATER, Player 1 Ready");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha4)) {
							p1a = Const.METAL;
							a1Ready = true;
							p1Ready = true;
							simulationScript.p1TotemScript.addPlaceholder();
							print("Player1Attack = METAL, Player 1 Ready");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha5)) {
							p1a = Const.EARTH;
							a1Ready = true;
							p1Ready = true;
							simulationScript.p1TotemScript.addPlaceholder();
							print("Player1Attack = EARTH, Player 1 Ready");
						}
						
					}



					// Player 2 Selections
					if(!s2Ready) {
						if (Input.GetKeyDown (KeyCode.Alpha6)) {
							p2s = Const.FOX;
							s2Ready = true;
							simulationScript.p2TotemScript.addPlaceholder();
							print("Player1Support = FOX");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha7)) {
							p2s = Const.MOOSE;
							s2Ready = true;
							simulationScript.p2TotemScript.addPlaceholder();
							print("Player1Support = MOOSE");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha8)) {
							p2s = Const.DRAGON;
							s2Ready = true;
							simulationScript.p2TotemScript.addPlaceholder();
							print("Player1Support = DRAGON");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha9)) {
							p2s = Const.ONI;
							s2Ready = true;
							simulationScript.p2TotemScript.addPlaceholder();
							print("Player1Support = ONI");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha0)) {
							p2s = Const.TANUKI;
							s2Ready = true;
							simulationScript.p2TotemScript.addPlaceholder();
							print("Player1Support = TANUKI");
						}
						
					} else if (!d2Ready) {
						if (Input.GetKeyDown (KeyCode.Alpha6)) {
							p2d = Const.FIRE;
							d2Ready = true;
							simulationScript.p2TotemScript.addPlaceholder();
							print("Player2Defense = FIRE");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha7)) {
							p2d = Const.WOOD;
							d2Ready = true;
							simulationScript.p2TotemScript.addPlaceholder();
							print("Player2Defense = WOOD");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha8)) {
							p2d = Const.WATER;
							d2Ready = true;
							simulationScript.p2TotemScript.addPlaceholder();
							print("Player2Defense = WATER");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha9)) {
							p2d = Const.METAL;
							d2Ready = true;
							simulationScript.p2TotemScript.addPlaceholder();
							print("Player2Defense = METAL");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha0)) {
							p2d = Const.EARTH;
							d2Ready = true;
							simulationScript.p2TotemScript.addPlaceholder();
							print("Player2Defense = EARTH");
						}

					}else if (!a2Ready) {
						if (Input.GetKeyDown (KeyCode.Alpha6)) {
							p2a = Const.FIRE;
							a2Ready = true;
							p2Ready = true;
							simulationScript.p2TotemScript.addPlaceholder();
							print("Player2Attack = FIRE, Player 2 Ready");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha7)) {
							p2a = Const.WOOD;
							a2Ready = true;
							p2Ready = true;
							simulationScript.p2TotemScript.addPlaceholder();
							print("Player2Attack = WOOD, Player 2 Ready");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha8)) {
							p2a = Const.WATER;
							a2Ready = true;
							p2Ready = true;
							simulationScript.p2TotemScript.addPlaceholder();
							print("Player2Attack = WATER, Player 2 Ready");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha9)) {
							p2a = Const.METAL;
							a2Ready = true;
							p2Ready = true;
							simulationScript.p2TotemScript.addPlaceholder();
							print("Player2Attack = METAL, Player 2 Ready");
						}
						else if (Input.GetKeyDown (KeyCode.Alpha0)) {
							p2a = Const.EARTH;
							a2Ready = true;
							p2Ready = true;
							simulationScript.p2TotemScript.addPlaceholder();
							print("Player2Attack = EARTH, Player 2 Ready");
						}
						
					}
				} 
				else if (p1Ready && p2Ready) {
					allReady = true;
					print("Both players ready");
				}
			}
			else {
				print ("fuck");
				TimerLabel.SetActive (false);
				InfoSheet.SetActive (false);
				simulationScript.p1Attack = p1a;
				simulationScript.p2Attack = p2a;
				simulationScript.p1Defense = p1d;
				simulationScript.p2Defense = p2d;
				simulationScript.p1Animal = p1s;
				simulationScript.p2Animal = p2s;
				simulationScript.totemsChosen = true;
				Reinitialization();
				CombatEnded = false;
			}
		}

	}

	public IEnumerator WhoWon () {
		
		projectile1.SetActive (true);
		Vector3 totem2Vector = totem2.transform.position;
		StartCoroutine (this.moveToPosition (projectile1.transform, totem2Vector, 2f));
		yield return new WaitForSeconds (2f);
		projectile1.SetActive (false);
		projectile1.transform.position = totem1.transform.position;

		projectile2.SetActive (true);
		Vector3 totem1Vector = totem1.transform.position;
		StartCoroutine (this.moveToPosition (projectile2.transform, totem1Vector, 2f));
		yield return new WaitForSeconds (2f);
		projectile2.SetActive (false);
		projectile2.transform.position = totem2.transform.position;


		StartCoroutine(ShowWinner());

	}

	private IEnumerator moveToPosition(Transform transform, Vector3 position, float timeToMove) {
		var currentPos = transform.localPosition;
		var t = 0f;
		while(t < 1) {
			t += Time.deltaTime / timeToMove;
			transform.localPosition = Vector3.Lerp(currentPos, position, t);
			yield return null;
		}
	}

	IEnumerator ShowWinner () {

		P1HP -= P1DmgTaken;
		P2HP -= P2DmgTaken;

		if (P1HP > 100){
			P1HP = 100;
		}

		if (P2HP > 100){
			P2HP = 100;
		}

		_P1hp.value = P1HP/100;
		_P2hp.value = P2HP/100;


		yield return new WaitForSeconds(3f);

		allReady = false;

		if (P1HP <= 0 || P2HP <= 0){
			CombatEnded = false; 

			ShowEndGameUI ();
			
		} else {
			CombatEnded = true;
		}


	}
	
}
