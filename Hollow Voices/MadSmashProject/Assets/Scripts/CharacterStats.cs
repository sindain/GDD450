using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterStats : MonoBehaviour {

	public GameObject[] lootDrop;

	private int iAgility;
	private int iStrength;
	private int iDefense;
	private int iStealth;
	private int   iLoot;
	private List<Buff> buffList;	

	// Use this for initialization
	void Start () {
		iAgility  = 5;
		iStrength = 5;
		iDefense  = 5;
		iStealth  = 5;
		iLoot     = 0;
		buffList = new List<Buff> ();
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Buff buff in buffList) {
      		buff.Update();
    	}
	}

	//------------------------------------------------------------------------------------------------
  //Name:         takeDamage
  //Description:  Handles taking damage and dropping loot
  //Parameters:   int piDamage - Amount of damage being inflicted.  Reduced by characters defense
  //Returns:      None
  //------------------------------------------------------------------------------------------------
	public void takeDamage(int piDamage){
		if (iLoot <= 0)
			return;
		int liTotalDamage = piDamage - iDefense > iLoot ? iLoot : piDamage - iDefense;
		int[] liLootDrops = new int[2];

		//Assign damage and determine amount of loot to drop
		iLoot = iLoot - liTotalDamage;
		GameObject.FindWithTag("HUD").GetComponent<HudScript>().addScore(-liTotalDamage);
		liLootDrops [1] = liTotalDamage / 5;
		liLootDrops [0] = liTotalDamage - liLootDrops[1] * 5;

		//Create correct amount of each type of loot and drop into world
		for(int i=0; i<2; i++){
			for (int j=0; j<liLootDrops[i]; j++) {
				GameObject lLootDrop = Instantiate (lootDrop [i], 
			                                    transform.position + new Vector3 (0, 1, 0), 
			                                    transform.rotation) as GameObject;
				lLootDrop.GetComponent<Rigidbody> ().AddForce (new Vector3 (0.0f, 200.0f, 0.0f));
			} //End for (int j=0; i<liLootDrops[i]; j++)
		} //End for(int i=0; i<2; i++)
	} //End public void takeDamage(int piDamage)

  //------------------------------------------------------------------------------------------------
  //Name:         addBuff
  //Description:  Handles adding buffs to the character
  //Parameters:   Buff pBuff - The buff that is being added to this character
  //Returns:      None
  //------------------------------------------------------------------------------------------------
  public void addBuff(Buff pBuff){
    buffList.Add (pBuff);
    pBuff.applyBuff (this.gameObject);
  }

	//Getters
	public int getAgility() {return iAgility;}
	public int getStrength(){return iStrength;}
	public int getDefense() {return iDefense;}
	public int getStealth() {return iStealth;}
	public int    getLoot() {return iLoot;}
	//Setters
	public void setAgility (int val){iAgility  = val;}
	public void setStrength(int val){iStrength = val;}
	public void setDefense (int val){iDefense  = val;}
	public void setStealth (int val){iStealth  = val;}
	public void setLoot    (int val){iLoot     = val;}
	//Adjusters
	public void adjAgility (int val){iAgility  = iAgility  + val < 0 ? 0 : iAgility  + val;}
	public void adjStrength(int val){iStrength = iStrength + val < 0 ? 0 : iStrength + val;}
	public void adjDefense (int val){iDefense  = iDefense  + val < 0 ? 0 : iDefense  + val;}
	public void adjStealth (int val){iStealth  = iStealth  + val < 0 ? 0 : iStealth  + val;}
	public void adjLoot    (int val){iLoot     = iLoot     + val < 0 ? 0 : iLoot     + val;}
}
