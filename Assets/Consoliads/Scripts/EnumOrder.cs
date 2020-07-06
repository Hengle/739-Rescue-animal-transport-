using UnityEngine;
using System.Collections;
using System;

//using System.Reflection;
//using System.Collections.Generic;

[System.AttributeUsage (System.AttributeTargets.Field)]
public class EnumOrder : PropertyAttribute {

	public readonly int[] order;
	
	/*public EnumOrder () {
		//this.order = new int[0];
	}*/

	public EnumOrder (string _orderStr) {
		this.order = StringToInts(_orderStr);
	}

	public EnumOrder (int[] _order) {
		this.order = _order;
	}

	int[] StringToInts (string str) {
		string[] stringArray = str.Split(',');
		int[] intArray = new int[stringArray.Length];
		for (int i=0; i<stringArray.Length; i++)
			intArray[i] = System.Int32.Parse (stringArray[i]);

		return (intArray);
	}

}