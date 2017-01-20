using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour {

	public int Strenght;
	public int Agility;
	public int Constitution;
	public int Armor;

	[HideInInspector]
	public int HP;
	public int HPMax { get { return Constitution * 5; } }

	public int DamageMin { get { return Strenght / 2; } }
	public int DamageMax { get { return DamageMin + 4; } }
	public int Accuracy { get { return 75 + Agility; } }
	public int Dodge { get { return Agility; } }

	public int Level;
	public int Experience;
	public int ExperienceToNextLevel { get { return 100 + Level * Level; } }

	public int Gold;

	private Creature target;

	public void Attack(Creature creature)
	{
		if (creature == null)
			creature = target;
		if (Random.Range (1, 100) > Accuracy - creature.Dodge)
			return;

		creature.OnDamaged(this, Random.Range (DamageMin, DamageMax) * (1 - creature.Armor / 200));
	}
	
	public void OnDamaged(Creature source, int damage)
	{
		HP -= damage;
		if (HP <= 0)
			OnDeath (source);
	}

	public void OnKill(Creature creature)
	{
		Gold += creature.Gold;
		GainExperience (creature.Experience);
	}

	public void OnDeath(Creature source)
	{
		//TODO Animation
	}

	public void OnLevelUp()
	{
	}

	public void GainExperience(int amount)
	{
		Experience += amount;
		if (Experience >= ExperienceToNextLevel) {
			Experience -= ExperienceToNextLevel;
			Level++;
			OnLevelUp ();
		}
	}

	private void Start()
	{
		HP = HPMax;
	}
}