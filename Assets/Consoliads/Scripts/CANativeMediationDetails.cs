using UnityEngine;
using System; 
using System.Collections;

[Serializable]
public class CANativeMediationDetails {

	[NonSerialized] public bool enabled = true;

	public const string nativeTypeOrder = "-1,27,69,58,44,63,78,75";
	[EnumOrder(nativeTypeOrder)]
	public AdNetworkNameNative[] networkList;

	public const string failOverTypeOrder = "-1,27,69,58,44,63,78,75";
	[EnumOrder(failOverTypeOrder)]
	public AdNetworkNameNative failOver;

    public int width;
    public int height;
}
