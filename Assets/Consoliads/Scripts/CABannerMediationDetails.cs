using UnityEngine;
using System; 
using System.Collections;

[Serializable]
public class CABannerMediationDetails {

    public Boolean enabled;
	public AdNetworkNameBanner[] networkList;
	public AdNetworkNameBanner failOver = AdNetworkNameBanner.NONE;

	public BannerSize size = BannerSize.Banner;
	public BannerPosition position = BannerPosition.Top;
}
