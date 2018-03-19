using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject {

	public string weaponName;
	public string weaponDescription;

	public Sprite weaponImage;

	public int weaponDamageAmount;
	public int weaponCostAmount;
	public int weaponClipAmount;

    public int weaponFireRate;

    public int weaponReloadTime;

    public Sprite bulletGFX;

}
