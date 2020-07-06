using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class CAInterstitialMediationDetails
{
	int count = 0;
	private bool isFirst = true;
	[HideInInspector] public bool skipFirst = false;

	public const string InterstitialTypeOrder = "-1,9,0,18,5,19,33,47,12,38,60,62,50,40,52,36,30,10,29";
	[EnumOrder(InterstitialTypeOrder)]
	public AdNetworkNameInterstitial[] networkList;

	public const string failOverTypeOrder = "-1,9,0,18,5,19,33,47,12,38,60,62,50,40,52,36,30,10,29";
	[EnumOrder(failOverTypeOrder)]
	public AdNetworkNameInterstitial failOver = AdNetworkNameInterstitial.EMPTY;


	public bool IsFirst
	{
		get
		{
			bool val = isFirst;
			isFirst = false;
			return val;
		}
	}


	public int Count
	{
		get
		{
			return count;
		}
		set
		{
			count = value;
		}
	}

}
