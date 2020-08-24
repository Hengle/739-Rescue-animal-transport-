using UnityEngine;
using System; 
using System.Collections;

[Serializable]
public class CANativeMediationDetails {

    public bool enabled;
	public AdNetworkNameNative[] networkList;
	public AdNetworkNameNative failOver = AdNetworkNameNative.EMPTY;

    public int width;
    public int height;
}
