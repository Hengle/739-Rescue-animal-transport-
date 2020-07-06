using UnityEngine;
using System; 
using System.Collections;

[Serializable]
public class CARewardedVideoMediationDetails
{
	private int count = 0;
	private bool isFirst = true;
	[HideInInspector] public bool skipFirst = false;

	public const string rewardedVideoTypeOrder = "-1,46,21,20,25,35,34,48,15,39,61,51,41,37,83,26,84";
	[EnumOrder(rewardedVideoTypeOrder)]
    public AdNetworkNameRewardedVideo[] networkList;

	public const string failOverTypeOrder = "-1,46,21,20,25,35,34,48,15,39,61,51,41,37,83,26,84";
	[EnumOrder(failOverTypeOrder)]
    public AdNetworkNameRewardedVideo failOver = AdNetworkNameRewardedVideo.EMPTY;

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
