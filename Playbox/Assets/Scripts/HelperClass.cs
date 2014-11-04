using UnityEngine;
using System.Collections;
using System;	// We need this for making or class sortable

// A helper class to illustrate the Lists.cs and Dictionaries.cs code.
public class HelperClass : IComparable<HelperClass>
{
	public string Name;
	public int Power;

	// Constructor
	public HelperClass(string newName, int newPower)
	{
		Name = newName;
		Power = newPower;
	}

	// Sorting section. +1 == bigger; 0 == same; -1 == smaller
	// This is used in ListsAndDicionaries Sort() section.
	public int CompareTo(HelperClass other)
	{
		// Does the bad guy exist?
		if(other == null)
		{
			return 1;
		}

		// Who has more power? This will sort in descending order.
		return (other.Power - Power);
	}
}
