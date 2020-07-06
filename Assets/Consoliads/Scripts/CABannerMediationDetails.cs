using UnityEngine;
using System; 
using System.Collections;

[Serializable]
public class CABannerMediationDetails {

	[NonSerialized] public Boolean enabled = true;

	public const string bannerTypeOrder = "-1,87,28,42,57,43,49,70,73,88,56,77,76,68";
	[EnumOrder(bannerTypeOrder)]
	public AdNetworkNameBanner[] networkList;

	public const string bannerFailOverTypeOrder = "-1,87,28,42,57,43,49,70,73,88,56,77,76,68";
	[EnumOrder(bannerFailOverTypeOrder)]
	public AdNetworkNameBanner failOver = AdNetworkNameBanner.NONE;

	public BannerSize size = BannerSize.Banner;
	public BannerPosition position = BannerPosition.Top;
}
